using System;

namespace Day_2
{
    // 1. Interface
    interface INotification
    {
        void Send(string message);
    }

    // 2. Email Notification
    class EmailNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Email sent: " + message);
        }
    }

    // 3. SMS Notification
    class SMSNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("SMS sent: " + message);
        }
    }

    // 4. Push Notification
    class PushNotification : INotification
    {
        public void Send(string message)
        {
            Console.WriteLine("Push Notification sent: " + message);
        }
    }

    // 5. Factory Class
    class NotificationFactory
    {
        public INotification CreateNotification(string type)
        {
            if (type.ToLower() == "email")
                return new EmailNotification();
            else if (type.ToLower() == "sms")
                return new SMSNotification();
            else if (type.ToLower() == "push")
                return new PushNotification();
            else
                return null;
        }
    }

    // 6. Main Class (Client)
    class Problem6
    {
        static void Main(string[] args)
        {
            NotificationFactory factory = new NotificationFactory();

            Console.Write("Enter notification type (email/sms/push): ");
            string type = Console.ReadLine();

            INotification notification = factory.CreateNotification(type);

            if (notification != null)
            {
                notification.Send("Welcome to our service!");
            }
            else
            {
                Console.WriteLine("Invalid notification type");
            }
        }
    }
}