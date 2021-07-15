using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSystem : MonoBehaviour
{
    public int levelCapacity = 0;
    private int experienceNeeded = 750;
    public int levelNumber = 0;
    void Update()
    {
        if(levelCapacity >= experienceNeeded)
        {
            levelNumber++;
            experienceNeeded += 150;
            levelCapacity = 0; 
        }
    }
}
