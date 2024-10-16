
using Inventory.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.Repositories
{
    public class ProductRepositories : IProductService
    {

        private readonly InventoryContext _context;
        private readonly ILogger<ProductRepositories> _logger;
        public ProductRepositories(InventoryContext context, ILogger<ProductRepositories> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<ResponseDetail<Product>> AddProduct(Product model)
        {
            var response = new ResponseDetail<Product>();
            try
            {

                var product = await _context.Products.FirstOrDefaultAsync(p => p.Name == model.Name);

                if (product is not null && product.InStock)
                {
                    product.Quantity += model.Quantity;
                    response = response.SuccessResultData("Product Successfully added");
                }
                else
                {
                    var new_product = new Product
                    {
                        Quantity = model.Quantity,
                        InStock = model.InStock,
                        Name = model.Name
                    };

                    await _context.AddAsync(new_product);
                    if (await _context.SaveChangesAsync() > 0)
                    {
                        response = response.SuccessResultData(new_product, "Product Successfully added");
                        _logger.LogInformation("Product successfully added", new_product);

                    }
                    else
                    {
                        response = response.FailedResultData("Error ");
                        _logger.LogError(message:"Error creating a new product");
                       
                    }



                }
            }
            catch (Exception ex)
            {
                response = response.FailedResultData($"{ex.Message}", ex.HResult);
                _logger.LogError(message: ex.Message);
            }
            return response;
        }

        public async Task<ResponseDetail<string>> DeleteProduct(int productId)
        {
            var response = new ResponseDetail<string>();
            try
            {

                var product = await _context.Products.FindAsync(productId);
                if (product is null)
                {
                    response = response.FailedResultData( "Product does not exist", 404);
                }
                else
                {
                    response = response.SuccessResultData("Product Successfully Deleted");
                }

            }
            catch (Exception ex)
            {
                response = response.FailedResultData($"{ex.Message}", ex.HResult);
            }
            return response;
        }

        public async Task<List<Product>> GetAllProducts() => _context.Products.ToList();
       

        public async Task<ResponseDetail<Product>> GetProductById(int productId)
        {
            var response = new ResponseDetail<Product>();
            try
            {
                
                var product = await _context.Products.FindAsync(productId);
                if(product is null)
                {
                    response = response.FailedResultData( "Product does not exist", 404);
                    _logger.LogError(message: $"Product with ID:{productId} does not exist");
                }
                else
                {
                    response = response.SuccessResultData(product);
                    _logger.LogInformation(message: $"Product with ID:{productId} was successfully fetched");
                }
                
            }
            catch (Exception ex)
            {
                response = response.FailedResultData( $"{ex.Message}", ex.HResult);
                _logger.LogError(ex.Message, ex.HResult);
            }
            return response;
        }

        public async Task<ResponseDetail<Product>> UpdateProduct(Product product)
        {
            var response = new ResponseDetail<Product>();
            try
            {

                var prod = await _context.Products.FindAsync(product.Id);
                if (prod is null)
                {
                    response = response.FailedResultData(new Product(), "Product does not exist", 404);
                }
                
                else
                {
                    prod.InStock = product.InStock;
                    prod.Name = product.Name;
                    prod.Quantity = product.Quantity;

                    _context.Update(prod);
                    await _context.SaveChangesAsync();
                    response = response.SuccessResultData(prod);
                }

            }
            catch (Exception ex)
            {
                response = response.FailedResultData(new Product(), $"{ex.Message}", ex.HResult);
            }
            return response;
        }

        public async Task<ResponseDetail<string>> UpdateProducts()
        {
            var response = new ResponseDetail<string>();
            try
            {

                var prod = await _context.Products
                    .Select(x => new
                    {
                        x.InStock,
                        x.Quantity
                    })
                    .Where(x => x.Quantity > 0 && !x.InStock)                 
                    .ExecuteUpdateAsync(x => x.SetProperty(p => p.InStock, true));
                if (prod > 0)
                {
                    response = response.SuccessResultData("All products were succcessfully updated");
                    _logger.LogInformation(message: "All products were succcessfully updated");
                }
                else
                {
                    response = response.FailedResultData("An error occured while saving the update changes to the database");
                    _logger.LogError(message: "An error occured while saving the update changes to the database");
                }
            }
            catch (Exception ex)
            {
                response = response.FailedResultData($"{ex.Message}", ex.HResult);
                _logger.LogError(ex.Message);
               
            }
            return response;
        }
    }
}
