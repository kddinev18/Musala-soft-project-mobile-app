using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateExcercises : MonoBehaviour
{
    private float time = 31f;
    private int timeContainer;
    private int numberOfGenerations = 0;
    private bool isStarted = false;
    private int randomExcercise;
    private int TrainingDone = 0;
    
    [SerializeField] private Text timeDesplay;
    [SerializeField] private ExcerciseHolder excerciseHolder;
    [SerializeField] private ExperienceSystem experienceSystem;

    public Text excercisesNameDisplay;
    public Text excercisesDescriptionDisplay;
    
    void Start()
    {
        timeDesplay.enabled = false;
        generate(excerciseHolder.excercises, excerciseHolder.description);
        StartCoroutine(wait());
    }

    void Update()
    {
        if (isStarted)
        {
            if (TrainingDone != 4)
            {
                time -= Time.deltaTime;
                timeContainer = (int)time;
                timeDesplay.text = timeContainer.ToString();
                if (time < 0)
                {
                    if (numberOfGenerations == 4)
                    {
                        timeDesplay.enabled = false;
                        excercisesNameDisplay.text = "Rest";
                        excercisesDescriptionDisplay.text = "Rest";
                        numberOfGenerations++;
                        isStarted = false;
                        StartCoroutine(wait());
                        time = 16f; 
                        TrainingDone++;
                        numberOfGenerations = 0;
                    }
                    else
                    {
                        timeDesplay.enabled = false;
                        generate(excerciseHolder.excercises, excerciseHolder.description);
                        time = 31f;
                        numberOfGenerations++;
                        isStarted = false;
                        StartCoroutine(wait());
                        experienceSystem.levelCapacity += 50;
                    }
                }
            }
            else
            {
                excercisesNameDisplay.text = "Training Complete";
                excercisesDescriptionDisplay.text = "";
            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        isStarted = true;
        yield return new WaitForSeconds(.1f);
        timeDesplay.enabled = true;
    }

    public void generate(string[] excercises, string[] description)
    {
        randomExcercise = Random.Range(0, 3);
        excercisesNameDisplay.text = excercises[randomExcercise];
        excercisesDescriptionDisplay.text = description[randomExcercise];
    }
}
