using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateExcercises : MonoBehaviour
{   
    [SerializeField] private DataHolder excerciseHolder;
    [SerializeField] private ExperienceSystem experienceSystem;

    [SerializeField] private Text excercisesNameDisplay;
    [SerializeField] private Text excercisesDescriptionDisplay;

    [SerializeField] private Animator loseWeightData;
    [SerializeField] private Button nextExerciseButton;
    public Text trainingsLeftDisplay;
    public int trainingsLeft = 4;
    public string leaveTime;



    private bool isStarted = false;
    private int excerciseDone = 1;

    void Start()
    {
        UserData userdata = SaveSystem.loadUserData();
        trainingsLeft = userdata.trainingsLeftToday;
        trainingsLeftDisplay.text = trainingsLeft.ToString();
        leaveTime = userdata.leaveTime;
        DateTime dateTime = DateTime.Parse(leaveTime);
        TimeSpan timeSpan = new TimeSpan(1, 0, 0, 0);
        if (dateTime.Subtract(System.DateTime.UtcNow) >= timeSpan)
        {
            trainingsLeft = 4;
            leaveTime = System.DateTime.UtcNow.ToString();
            SaveSystem.saveUserData(this);
        }
    }

    public void nextExcercise()
    {
        generateExcercise(excerciseHolder.excercises, excerciseHolder.description);
    }
    
    void Update()
    {
        if(excerciseDone == 15)
        {
            nextExerciseButton.interactable = false;
            trainingsLeft--;
            excerciseDone = 1;
            trainingsLeftDisplay.text = trainingsLeft.ToString();
            excercisesNameDisplay.text = "Congratulations";
            excercisesDescriptionDisplay.text = "Training Done";
            leaveTime = DateTime.UtcNow.ToString();
            SaveSystem.saveUserData(this);
        }
    }

    private void generateExcercise(string[] excerciseName, string[] excerciseDesc)
    {
        int randomindex = UnityEngine.Random.Range(0, excerciseHolder.excercises.Length);
        excercisesNameDisplay.text = excerciseName[randomindex];
        excercisesDescriptionDisplay.text = excerciseDesc[randomindex];
        excerciseDone++;
    }
}
