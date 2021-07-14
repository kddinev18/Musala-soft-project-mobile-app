using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    public void CreateNotificationChannel()
    {
        var c = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(c);
    }

    public void SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "SomeTitle";
        notification.Text = "SomeText";
        notification.FireTime = System.DateTime.Now.AddSeconds(5);

        AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }
}
