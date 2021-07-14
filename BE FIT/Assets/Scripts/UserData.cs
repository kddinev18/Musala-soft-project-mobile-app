using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserData
{
    public int trainingsLeftToday;
    public int trainingsLeftThisWeek;

    public UserData(GenerateExcercises generateExcercises)
    {
        trainingsLeftToday = generateExcercises.trainingsLeft;
        trainingsLeftThisWeek = generateExcercises.trainingsLeftWeek;

    }
}
