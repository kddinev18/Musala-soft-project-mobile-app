using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;

public class NotificationManager : MonoBehaviour
{
    public void CreateNotificationChannel()
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

    public void SendNotification()
    {
        var notification = new AndroidNotification();
        notification.Title = "Time for some water";
        notification.Text = "After the training you must dring water."+'\n'+"Stay hydrated!";
        notification.FireTime = System.DateTime.Now.AddMinutes(1);

        AndroidNotificationCenter.SendNotification(notification, "dring water");
        Debug.Log("1");
    }
}
