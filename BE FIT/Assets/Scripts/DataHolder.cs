using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System;
using System.Linq;

public class DataHolder : MonoBehaviour
{
    public string[] excercises;
    public string[] descriptionContainer;
    public string[] description;
    public string[] calories;
    public string[] healthyFoodName;
    public string[] healthyFoodDesc;
    public string[] healthyFoodDescConatiner;

    [SerializeField] private NotificationManager notificationManager;

    void Start()
    {
        try
        {
            excercises = File.ReadAllLines("Assets\\Data Files\\ExcerciseNameData.txt").ToArray();
            descriptionContainer = File.ReadAllLines("Assets\\Data Files\\ExcerciseDescriptionData.txt").ToArray();
            calories = File.ReadAllLines("Assets\\Data Files\\ExcerciseCaloriesData.txt").ToArray();

            healthyFoodName = File.ReadAllLines("Assets\\Data Files\\HealthyFoodNameData.txt").ToArray();
            healthyFoodDescConatiner = File.ReadAllLines("Assets\\Data Files\\HealthyFoodDescData.txt").ToArray();
        }
        catch(Exception e)
        {
            notificationManager.createErrorNotificationChannel();
            notificationManager.SendErrorNotification(e.Message);
        }

        description = new string [descriptionContainer.Length];
        for (int i = 0; i < descriptionContainer.Length; i++)
        {
            description[i] = separate(descriptionContainer[i]);
        }

        healthyFoodDesc = new string[healthyFoodDescConatiner.Length];
        for (int i = 0 ; i < healthyFoodDescConatiner.Length; i++)
        {
            healthyFoodDesc[i] = separate(healthyFoodDescConatiner[i]);
        }
    }

    string separate(string desc , char replaceWith = '\n', char replaceWhat = ',')
    {
        desc = desc.Replace(replaceWhat, replaceWith);

        return desc;
    }
}
