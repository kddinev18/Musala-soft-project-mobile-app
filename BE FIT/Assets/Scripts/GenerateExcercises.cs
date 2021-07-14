using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    public Text trainingsLeftWeekDisplay;
    public int trainingsLeftWeek = 28;



    private bool isStarted = false;
    private int excerciseDone = 1;

    void Start()
    {
        UserData userdata = SaveSystem.loadUserData();
        trainingsLeft = userdata.trainingsLeftToday;
        trainingsLeftWeek = userdata.trainingsLeftThisWeek;
        trainingsLeftDisplay.text = trainingsLeft.ToString();
        trainingsLeftWeekDisplay.text = trainingsLeftWeek.ToString();
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
            trainingsLeftWeek--;
            trainingsLeftDisplay.text = trainingsLeft.ToString();
            trainingsLeftWeekDisplay.text = trainingsLeftWeek.ToString();
            excercisesNameDisplay.text = "Congratulations";
            excercisesDescriptionDisplay.text = "Training Done";
            SaveSystem.saveUserData(this);
        }
    }

    private void generateExcercise(string[] excerciseName, string[] excerciseDesc)
    {
        int randomindex = Random.Range(0, excerciseHolder.excercises.Length);
        excercisesNameDisplay.text = excerciseName[randomindex];
        excercisesDescriptionDisplay.text = excerciseDesc[randomindex];
        excerciseDone++;
    }
}
