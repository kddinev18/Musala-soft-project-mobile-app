using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayStats : MonoBehaviour
{
    [SerializeField] private Text levelDisplay;
    [SerializeField] private Text trainingsDoneDisplay;
    [SerializeField] private Text fatBurntDisplay;

    [SerializeField] private ExperienceSystem experienceSystem;
    [SerializeField] private GenerateExcercises generateExcercises;

    public int fatBurntCount = 0;
    void Update()
    {
        levelDisplay.text = experienceSystem.levelNumber.ToString();
        trainingsDoneDisplay.text = generateExcercises.trainingsDone.ToString();
        fatBurntDisplay.text = fatBurntCount.ToString();
    }
}
