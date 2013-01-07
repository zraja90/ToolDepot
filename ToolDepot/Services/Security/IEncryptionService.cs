
namespace ToolDepot.Services.Security 
{
    public interface IEncryptionService 
    {
        string EncryptPassword(string password);
        bool VerifyPassword(string password, string hashedPassword);
    }
}
