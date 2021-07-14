using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserData
{
    public int trainingsLeftToday;
    public string leaveTime;
    public UserData(GenerateExcercises generateExcercises)
    {
        trainingsLeftToday = generateExcercises.trainingsLeft;
        leaveTime = generateExcercises.leaveTime;
    }
}
