using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5
{
    public interface IAuthenticationService
    {
        bool AuthenticateUser(string username, string password);
        bool AuthorizeUser(string username, string requiredRole);
    }

    public class BasicAuthenticationService : IAuthenticationService
    {
        private readonly Dictionary<string, string> _users = new Dictionary<string, string>
        {
            { "admin", "securepass123" },
            { "guest", "read123" }
        };

        private readonly Dictionary<string, string> _userRoles = new Dictionary<string, string>
        {
            { "admin", "Administrator" },
            { "guest", "User" }
        };

        public bool AuthenticateUser(string username, string password)
        {
            Console.WriteLine($"authenticate user: {username}.....");

            if (_users.TryGetValue(username, out string storedPassword) && storedPassword == password)
            {
                Console.WriteLine("Authentication successful!");
                return true;
            }

            Console.WriteLine("Authentication failed. Invalid username or password.");
            return false;
        }

        public bool AuthorizeUser(string username, string requiredRole)
        {
            Console.WriteLine($"Check authorization for user '{username}' for role '{requiredRole}'...");

            if (_userRoles.TryGetValue(username, out string userRole) && userRole == requiredRole)
            {
                Console.WriteLine($"Authorization successful! User '{username}' has role '{requiredRole}'");
                return true;
            }

            Console.WriteLine($"Authorization failed. User '{username}' does not have role '{requiredRole}'.");
            return false;
        }
    }

    public class ExternalAuthenticationService : IAuthenticationService
    {
        private bool ConnectToIdentityServer(string username, string password)
        {
            Console.WriteLine($"[ExternalAuth] -> Attempting connection to Identity Server...");
            return username == "apiuser" && password == "tokensecret";
        }

        private string GetRoleFromToken(string username)
        {
            switch (username)
            {
                case "apiuser":
                    return "API_Client";

                case "manager":
                    return "Manager";

                default:
                    return "Guest";
            };
        }

        public bool AuthenticateUser(string username, string password)
        {
            Console.WriteLine($"\n[ExternalAuth] -> Authenticating user: {username}...");
            if (ConnectToIdentityServer(username, password))
            {
                Console.WriteLine("[ExternalAuth] -> Authentication successful!");
                return true;
            }
            Console.WriteLine("[ExternalAuth] -> Authentication failed.");
            return false;
        }

        public bool AuthorizeUser(string username, string requiredRole)
        {
            string userRole = GetRoleFromToken(username);
            Console.Write($"[ExternalAuth] -> Checking authorization for '{username}'. User role is '{userRole}'. ");

            if (userRole == requiredRole)
            {
                Console.WriteLine("Authorized.");
                return true;
            }
            Console.WriteLine("Denied.");
            return false;
        }
    }

}
