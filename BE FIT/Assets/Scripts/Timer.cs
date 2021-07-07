using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    private float time = 31f;
    private int timeContainer;
    private int numberOfGenerations = 0;
    bool isStarted = false;
    [SerializeField] private Text timeDesplay;
    [SerializeField] private GenerateExcercise generateExcercise;
    public Text excercisesNameDisplay;
    public Text excercisesDescriptionDisplay;
    void Start()
    {
        generateExcercise.generate();
        StartCoroutine(wait());
    }

    void Update()
    {
        if (isStarted)
        {
            time -= Time.deltaTime;
            timeContainer = (int)time;
            timeDesplay.text = timeContainer.ToString();
            if (time < 0)
            {
                if (numberOfGenerations == 4)
                {
                    excercisesNameDisplay.text = "Rest";
                    excercisesDescriptionDisplay.text = "Rest";
                    numberOfGenerations++;
                    isStarted = false;
                    StartCoroutine(wait());
                    time = 15f;
                }
                else
                {
                    generateExcercise.generate();
                    time = 31f;
                    numberOfGenerations++;
                    isStarted = false;
                    StartCoroutine(wait());
                }

            }
        }
    }
    IEnumerator wait()
    {
        yield return new WaitForSeconds(3f);
        isStarted = true;
    }
}
