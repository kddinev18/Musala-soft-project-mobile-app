using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceSystem : MonoBehaviour
{
    public int levelCapacity = 0;
    private int experienceNeeded = 150;
    private int levelNumber = 0;
    [SerializeField] private Text levelDesplay;
    void Update()
    {
        if(levelCapacity >= experienceNeeded)
        {
            levelNumber++;
            experienceNeeded += 150;
            levelDesplay.text = levelNumber.ToString();
            levelCapacity = 0; 
        }
    }
}
