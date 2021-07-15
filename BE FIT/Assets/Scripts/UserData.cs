using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class UserData
{
    public int trainingsLeftToday;
    public string leaveTime;
    public int fatBurntCount;
    public int trainingsDone;
    public int level;
    public UserData(GenerateExcercises generateExcercises)
    {
        trainingsLeftToday = generateExcercises.trainingsLeft;
        leaveTime = generateExcercises.leaveTime;
        fatBurntCount = generateExcercises.displayStats.fatBurntCount;
        trainingsDone = generateExcercises.trainingsDone;
        level = generateExcercises.experienceSystem.levelNumber;
    }
}
