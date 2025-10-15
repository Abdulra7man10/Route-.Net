using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*#region 1
            Circle myCircle = new Circle(5.0);
            myCircle.DisplayShapeInfo();

            Console.WriteLine(new string('-', 21));

            Rectangle myRectangle = new Rectangle(10.0, 4.5);
            myRectangle.DisplayShapeInfo();
            #endregion*/

            /*#region 2
            Console.WriteLine("--- Test 1: Successful ---");

            IAuthenticationService authService = new BasicAuthenticationService();

            string adminUsername = "admin";
            string adminPassword = "securepass123";
            string requiredAdminRole = "Administrator";

            bool isAuthenticated = authService.AuthenticateUser(adminUsername, adminPassword);

            if (isAuthenticated)
            {
                authService.AuthorizeUser(adminUsername, requiredAdminRole);
            }
            else
                Console.WriteLine("Skipping authorization because failed authentication.");

            Console.WriteLine("\n" + new string('=', 50) + "\n");

            Console.WriteLine("--- Test 2: Failed ---");

            string guestUsername = "guest";
            string wrongPassword = "12345";
            string requiredManagerRole = "Manager";

            isAuthenticated = authService.AuthenticateUser(guestUsername, wrongPassword);

            if (isAuthenticated)
            {
                authService.AuthorizeUser(guestUsername, requiredManagerRole);
            }
            else
            {
                Console.WriteLine("Skipping authorization because failed authentication.");
            }

            Console.WriteLine("\n" + new string('=', 50) + "\n");


            Console.WriteLine("--- Test 3: Exeternal ---");
            IAuthenticationService externalAuthService = new ExternalAuthenticationService();

            // Test successful external login
            externalAuthService.AuthenticateUser("apiuser", "tokensecret");
            externalAuthService.AuthorizeUser("apiuser", "API_Client"); // Should pass

            // Test failed external login
            externalAuthService.AuthenticateUser("baduser", "12345"); // should fail

            externalAuthService.AuthenticateUser("manager", "tokensecret");
            externalAuthService.AuthorizeUser("manager", "User"); // Should fail
            #endregion*/

            #region 3
            string emailRecipient = "abdo144418@gmail.com";
            string smsRecipient = "+201143685049";
            string pushRecipient = "device_token_xyz123";
            string notificationMessage = "Your order #1001 is done!";

            Console.WriteLine("--- Notification System Initialization ---");
            Console.WriteLine($"Message to send: \"{notificationMessage}\"\n");

            INotificationService emailService = new EmailNotificationService();
            INotificationService smsService = new SmsNotificationService();
            INotificationService pushService = new PushNotificationService();
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Executing Email Strategy:");
            emailService.SendNotification(emailRecipient, notificationMessage);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Executing SMS Strategy:");
            smsService.SendNotification(smsRecipient, notificationMessage);
            Console.WriteLine("------------------------------------------");

            Console.WriteLine("Executing Push Strategy:");
            pushService.SendNotification(pushRecipient, notificationMessage);
            Console.WriteLine("------------------------------------------");
        #endregion
    }
    }
}
