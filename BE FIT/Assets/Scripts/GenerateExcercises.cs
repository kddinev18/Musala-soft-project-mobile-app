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
    [SerializeField] private Animator loseWeight;
    [SerializeField] private Button nextExerciseButton;
    [SerializeField] private NotificationManager notificationManager;
    [SerializeField] private Sprite []exerciseSprites;
    [SerializeField] private Image spriteRenderer;
    public Text trainingsLeftDisplay;
    public int trainingsLeft = 4;
    public string leaveTime;
    public int trainingsDone = 0;
    public bool isTrainingDone = false;
    private int excerciseDone = 1;
    private int prevRandom = -1;

    void Start()
    {
        StartCoroutine(wait());
    }

    void resetTrainings()
    {
        DateTime dateTime = DateTime.Parse(leaveTime);
        TimeSpan timeSpan = new TimeSpan(1, 0, 0, 0);
        if (System.DateTime.UtcNow.Subtract(dateTime) >= timeSpan)
        {
            trainingsLeft = 4;
            trainingsLeftDisplay.text = trainingsLeft.ToString();
            leaveTime = System.DateTime.UtcNow.ToString();
            SaveSystem.saveUserData(this);
        }
    }

    public void startTraining()
    {
        if (!(trainingsLeft == 0))
        {
            isTrainingDone = false;
            nextExerciseButton.interactable = true;
            loseWeight.SetBool("goBack", false);
            loseWeight.SetBool("isTraining", true);
            nextExcercise();
        }
    }
    public void nextExcercise()
    {

         spriteRenderer.enabled = true;
         generateExcercise(excerciseHolder.excercises, excerciseHolder.calories);
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
            excercisesNameDisplay.text = "Training Done";
            spriteRenderer.enabled = false;
            isTrainingDone = true;
            StartCoroutine(waitSave());
            notificationManager.createNotificationChannel();
            notificationManager.SendNotification();
        }
    }

    private void generateExcercise(string[] excerciseName, string[] calories)
    {
        int randomindex = UnityEngine.Random.Range(0, excerciseHolder.excercises.Length);
        if (prevRandom == randomindex)
        {
            generateExcercise(excerciseName, calories);
        }
        else
        {
            spriteRenderer.sprite = exerciseSprites[randomindex];
            prevRandom = randomindex;
            excercisesNameDisplay.text = excerciseName[randomindex];
            Int32.TryParse(calories[randomindex], out int fatBurntCointainer);
            displayStats.fatBurntCount += fatBurntCointainer;
            excerciseDone++;
        }
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
        experienceSystem.levelCapacity += 100;
        trainingsDone++;
        yield return new WaitForSeconds(.5f);
        SaveSystem.saveUserData(this);
    }
}
