using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace SprintManager.WebApi.AppStart
{
    public class AuthOptions
    {
        public const string ISSUER = "AuthServer";
        public const string AUDIENCE = "AuthClient";
        public const string KEY = "0E86FB4B-9C03-4FD0-BB72-AA6628A363A2";
        public const int LIFETIME = 60;
        
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }

    }
}