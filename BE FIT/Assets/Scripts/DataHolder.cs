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
    public string[] description;
    public string[] calories;
    public string[] healthyFoodName;
    public string[] healthyFoodDesc;

    void Start()
    {
        excercises = File.ReadAllLines("Assets\\Data Files\\ExcerciseNameData.txt").ToArray();
        description = File.ReadAllLines("Assets\\Data Files\\ExcerciseDescriptionData.txt").ToArray();
        calories = File.ReadAllLines("Assets\\Data Files\\ExcerciseCaloriesData.txt").ToArray();

        healthyFoodName = File.ReadAllLines("Assets\\Data Files\\HealthyFoodNameData.txt").ToArray();
        healthyFoodDesc = File.ReadAllLines("Assets\\Data Files\\HealthyFoodDescData.txt").ToArray();
    }
}
