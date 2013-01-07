using System.Web.Helpers;

namespace ToolDepot.Services.Security
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
           return  Crypto.VerifyHashedPassword(hashedPassword, password);
        }
    }
}
