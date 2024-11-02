
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using static System.Net.Mime.MediaTypeNames;

namespace Inventory.Repositories
{
    public class RegisterRepository : IRegister
    {
        private readonly InventoryContext context;
        private readonly ILogger<RegisterRepository> logger;
        private readonly AppSettings appSettings;
        
        public RegisterRepository(InventoryContext context, ILogger<RegisterRepository> logger, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this.logger = logger;
            this.appSettings = appSettings.Value;
        }
        public async Task<ResponseDetail<User>> RegisterAsync(UserRegisterDTO model)
        {
            var response = new ResponseDetail<User>();
            var maxFileSize = appSettings.MaxFileSize * 1024 * 1024;
            if(model.IdentificationDocument.Length > maxFileSize)
            {
                return response.FailedResultData($"File size has exceeded allowed limit of {appSettings}mb");
            }

            //Using extension
            //var fileExtension = Path.GetExtension(model.IdentificationDocument.FileName);
            //if (!fileExtension.ToLower().Equals(".pdf"))
            //    //&& !fileExtension.ToLower().Equals(".doc")
            //    //&& !fileExtension.ToLower().Equals(".docx"))
            //{
            //    return response.FailedResultData("Only PDF or Word documents are allowed");
            //}

            //Using the MIME Type/ Content Type
            var fileExtension = new List<string>
            {
                "application/msword",
                "application/vnd.openxmlformats-officedocument.wordprocessingml.document",
                "application/pdf"
            };

            if (!fileExtension.Contains(model.IdentificationDocument.ContentType))
            {
                return response.FailedResultData("Only PDF or Word documents are allowed");
            }

            try
            {
                var userExists = await context.Users.AnyAsync(x => x.Email == model.Email);
                if(userExists)
                {
                    return response.FailedResultData($"User with {model.Email} already exists");
                }

                var folderPath = Path.Combine(appSettings.StoragePath, model.Email);//Documents/Afeez@gmail.com
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                var filePath = Path.Combine(folderPath, model.IdentificationDocument.FileName.ToLower()); //Documents/Afeez@gmail.com/NIN.pdf
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await model.IdentificationDocument.CopyToAsync(stream);
                };

                var user = new User
                {
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    PhoneNumber = model.PhoneNumber,
                    Documents = []
                     
                };
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();

                var document = new Document
                {
                    Name = model.IdentificationDocument.FileName,
                    Path = filePath,
                    UserId = user.ID,
                    Extension = Path.GetExtension(model.IdentificationDocument.FileName)
                };

                user.Documents.Add(document);
                await context.SaveChangesAsync();
                return response.SuccessResultData(user);
            }
            catch(Exception ex)
            {
                return response.FailedResultData(ex.Message);
            }
        }
    }
}
