using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GenerateExcercises : MonoBehaviour
{   
    [SerializeField] private DataHolder excerciseHolder;
    public ExperienceSystem experienceSystem;
    public DisplayStats displayStats;

    [SerializeField] private Text excercisesNameDisplay;
    [SerializeField] private Text excercisesDescriptionDisplay;

    [SerializeField] private Animator loseWeightData;
    [SerializeField] private Button nextExerciseButton;
    [SerializeField] private NotificationManager notificationManager;
    public Text trainingsLeftDisplay;
    public int trainingsLeft = 4;
    public string leaveTime;

    public int trainingsDone = 0;

    private bool isStarted = false;
    private int excerciseDone = 1;

    void Start()
    {
        StartCoroutine(wait());
    }

    void resetTrainings()
    {
        DateTime dateTime = DateTime.Parse(leaveTime);
        TimeSpan timeSpan = new TimeSpan(1, 0, 0, 0);
        Debug.Log(dateTime + "     " + System.DateTime.UtcNow.Subtract(dateTime) + "     " + timeSpan);
        if (System.DateTime.UtcNow.Subtract(dateTime) >= timeSpan)
        {
            trainingsLeft = 4;
            trainingsLeftDisplay.text = trainingsLeft.ToString();
            leaveTime = System.DateTime.UtcNow.ToString();
            SaveSystem.saveUserData(this);
        }
    }

    public void nextExcercise()
    {
        generateExcercise(excerciseHolder.excercises, excerciseHolder.description, excerciseHolder.calories);
        experienceSystem.levelCapacity += 50;
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
            StartCoroutine(waitSave());
            notificationManager.createNotificationChannel();
            notificationManager.SendNotification();
        }
    }

    private void generateExcercise(string[] excerciseName, string[] excerciseDesc, string[] calories)
    {
        int randomindex = UnityEngine.Random.Range(0, excerciseHolder.excercises.Length);
        excercisesNameDisplay.text = excerciseName[randomindex];
        excercisesDescriptionDisplay.text = excerciseDesc[randomindex];
        int fatBurntCointainer;
        Int32.TryParse(calories[randomindex], out int cointainer);
        displayStats.fatBurntCount += cointainer;
        excerciseDone++;
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.2f);
        UserData userdata = SaveSystem.loadUserData();
        trainingsLeft = userdata.trainingsLeftToday;
        trainingsLeftDisplay.text = trainingsLeft.ToString();
        leaveTime = userdata.leaveTime;
        trainingsDone = userdata.trainingsDone;
        displayStats.fatBurntCount = userdata.fatBurntCount;
        experienceSystem.levelNumber = userdata.level;

        resetTrainings();
    }

    IEnumerator waitSave()
    {
        leaveTime = DateTime.UtcNow.ToString();
        Debug.Log(leaveTime);
        experienceSystem.levelCapacity += 100;
        trainingsDone++;
        yield return new WaitForSeconds(.5f);
        SaveSystem.saveUserData(this);
    }
}
