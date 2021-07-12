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
    void Start()
    {
        
    }

    void Update()
    {
       
    }

    private void generateExcercise(string[] excerciseName, string[] excerciseDesc, string excerciseTime)
    {
        int randomindex = Random.Range(0f, 3f);
        excercisesNameDisplay = excerciseName[randomindex];
        excercisesDescriptionDisplay = excerciseDesc[randomindex];
        timeDesplay = excerciseTime[randomindex];
    }


    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        isStarted = true;
        yield return new WaitForSeconds(.1f);
        timeDesplay.enabled = true;
    }
}
