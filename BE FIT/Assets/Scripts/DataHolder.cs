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
    public string[] calories;
    public string[] count;
    public string[] healthyFoodName;
    public string[] healthyFoodDesc;

    [SerializeField] private TextAsset excerciseNameData;
    [SerializeField] private TextAsset excerciseCountData;
    [SerializeField] private TextAsset excerciseCaloriesData;
    [SerializeField] private TextAsset healthyFoodNameData;
    [SerializeField] private TextAsset healthyFoodDescData;

    [SerializeField] private NotificationManager notificationManager;

    void Start()
    {
        try
        {
            excercises = new string[countWords(excerciseNameData.text)];
            excercises = separate(excerciseNameData.text, excercises);

            calories = new string[countWords(excerciseCaloriesData.text)];
            calories = separate(excerciseCaloriesData.text, calories);

            count = new string[countWords(excerciseCountData.text)];
            count = separate(excerciseCountData.text, count);

            healthyFoodName = new string[countWords(healthyFoodNameData.text)];
            healthyFoodName = separate(healthyFoodNameData.text, healthyFoodName);

            healthyFoodDesc = new string[countWords(healthyFoodDescData.text)];
            healthyFoodDesc = separate(healthyFoodDescData.text, healthyFoodDesc);
        }
        catch(Exception e)
        {
            notificationManager.createErrorNotificationChannel();
            notificationManager.SendErrorNotification(e.Message);
        }
    }

    int countWords(string text)
    {
        int count = 1;
        for(int i=0;i<text.Length;i++)
        {
            if(text[i] == ',')
            {
                count++;
            }
        }
        return count;
    }

    string[] separate(string text, string[] arg)
    {
        int argCount = 0;
        for(int i=0;i<text.Length;i++)
        {
            if(text[i] == ',')
            {
                argCount++;
            }
            else
            {
                arg[argCount] += text[i];
            }
        }
        return arg;
    }
}
