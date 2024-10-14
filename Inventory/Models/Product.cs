global using System.ComponentModel.DataAnnotations;

namespace Inventory.Models
{
    
    public class Product
    {
        private bool _inStock;
        private int _quantity;

        public Product()
        {
            var stockValue = new Random();
            int val= stockValue.Next(0, 2);
            _inStock = val == 0 ? false : true;
            _quantity = stockValue.Next(1, 20);
        }
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public bool InStock { get { return _inStock; } set { _inStock = value; } }
        public int Quantity { get { return _quantity; } set { _quantity = value; } }
        
       
    }
}
