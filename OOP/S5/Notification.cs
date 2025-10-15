using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S5
{
    public interface INotificationService
    {
        void SendNotification(string recipient, string message);
    }

    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[EMAIL] To: {recipient}");
            Console.WriteLine($"[EMAIL] Message: '{message}'");
            Console.WriteLine("[EMAIL] Status: Email sent successfully.");
            Console.ResetColor();
        }
    }

    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"[SMS] To: {recipient}");
            Console.WriteLine($"[SMS] Message: '{message}'");
            Console.WriteLine("[SMS] Status: SMS sent.");
            Console.ResetColor();
        }
    }

    public class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipient, string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"[PUSH] To Device ID: {recipient}");
            Console.WriteLine($"[PUSH] Message: '{message}'");
            Console.WriteLine("[PUSH] Status: Notification pushed.");
            Console.ResetColor();
        }
    }
}
