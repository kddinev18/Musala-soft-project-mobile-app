using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateExcercises : MonoBehaviour
{   
    [SerializeField] private ExcerciseHolder excerciseHolder;
    [SerializeField] private ExperienceSystem experienceSystem;

    [SerializeField] private Text excercisesNameDisplay;
    [SerializeField] private Text excercisesDescriptionDisplay;
    [SerializeField] private Text timeDesplay;

    [SerializeField] private Animator loseWeightData;

    private bool isStarted = false;
    private int excerciseDone = 1;

    public void nextExcercise()
    {
        StartCoroutine(wait());
    }

    private void generateExcercise(string[] excerciseName, string[] excerciseDesc, string[] excerciseCount)
    {
        int randomindex = Random.Range(0, 3);
        excercisesNameDisplay.text = excerciseName[randomindex];
        excercisesDescriptionDisplay.text = excerciseDesc[randomindex];
        timeDesplay.text = excerciseCount[randomindex];
    }

    IEnumerator wait()
    {
        loseWeightData.SetBool("isNewExercise", true);
        loseWeightData.SetBool("generateNewExercise", true);
        yield return new WaitForSeconds(1.05f);
        loseWeightData.SetBool("isNewExercise", false);
        loseWeightData.SetBool("generateNewExercise", false);
        generateExcercise(excerciseHolder.excercises, excerciseHolder.description, excerciseHolder.count);
    }
}
