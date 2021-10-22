using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;

namespace Portfolio.Attributes
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            //var ctx = (AppDatabaseContext)validationContext.GetService(typeof(AppDatabaseContext));
            var file = value as IFormFile;
            if(file != null)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { "png", "jpg", "jpeg" };
                bool result = extension.Any(e => extension.EndsWith(e));
                if (!result)
                    return new ValidationResult(GetErrorMessage());
            }
            return ValidationResult.Success;
        }

        private string GetErrorMessage()
        {
            return "Allowed extensions are jpg, png and jpeg";
        }
    }
}
