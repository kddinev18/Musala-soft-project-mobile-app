using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    public void createNotificationChannel()
    {
        var dringWater = new AndroidNotificationChannel()
        {
            Id = "dring water",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(dringWater);
    }

    public void createErrorNotificationChannel()
    {
        var error = new AndroidNotificationChannel()
        {
            Id = "error",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(error);
    }

    public void SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Time for some water";
        notification.Text = "After the training you must dring water."+'\n'+"Stay hydrated!";
        notification.FireTime = System.DateTime.Now;

        AndroidNotificationCenter.SendNotification(notification, "dring water");
    }

    public void SendErrorNotification(string errorCode)
    {
        var notification = new AndroidNotification();
        notification.Title = "Fatal Error!";
        notification.Text = errorCode + '\n' + "Try reinstalling the app.";
        notification.FireTime = System.DateTime.Now;

        AndroidNotificationCenter.SendNotification(notification, "error");
    }
}
