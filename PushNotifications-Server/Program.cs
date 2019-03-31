using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebPush;

namespace PushNotificationsForWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            var pushEndpoint = @"https://fcm.googleapis.com/fcm/send/ekMoPa5M89k:APA91bGSnaAEK21NWR69KJxhpI9ZclSYQaO-8DN5L40IMTvx_UcwAa9oH9gxxx-8834FS6W8PgwArP6egp-Ril71C1lTYlfVfvR7QanXFofGm6NrrB4tnWroDt6JWHboHWRxTyvBmcd5";
            var p256dh = @"BMEr_A0XQNoa2_wevytCIroFOKACBaF4lM2XC5u8UJf1wH49rTdQHb1-ZH0RFqb9vrwmwscpDealrRQxaVk_iXQ";
            var auth = @"hOUcWVViA9HnI_VIA7QAoA";

            var subject = @"mailto:example@example.com";
            var publicKey = @"BJaJhptAZrZpv2sL7ispNtdKLitrdJviE0tLSi9uVROolaN_ciR3_oGKwkwj9MyKT3HpyQhQ3otG4WzbDOn-p5Y";
            var privateKey = @"y3ZV-hUWfk98sDRyQIsgLSFHAgLfw_VAXzHecTVJhig";

            var subscription = new PushSubscription(pushEndpoint, p256dh, auth);
            var vapidDetails = new VapidDetails(subject, publicKey, privateKey);
            //var gcmAPIKey = @"[your key here]";

            var webPushClient = new WebPushClient();
            try
            {
                webPushClient.SendNotification(subscription, "Hello World", vapidDetails);
                //webPushClient.SendNotification(subscription, "payload", gcmAPIKey);
            }
            catch (WebPushException exception)
            {
                Console.WriteLine("Http STATUS code" + exception.StatusCode);
            }
        }
    }
}
