using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GenerateExcercise : MonoBehaviour
{
    private string[] excercisesName = {"jumping jacks","plank","push ups"};
    private string[] excercisesDescription = {"1","2","3"};
    private int randomExcercise;
    [SerializeField] private Timer timer;
    public void generate()
    {
        randomExcercise = Random.Range(0, 3);
        timer.excercisesNameDisplay.text = excercisesName[randomExcercise];
        timer.excercisesDescriptionDisplay.text = excercisesDescription[randomExcercise];
    }
}
