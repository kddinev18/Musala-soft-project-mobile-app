using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator menu;
    [SerializeField] private Animator loseWeight;
    [SerializeField] private Animator HealthyFood;
    [SerializeField] private GenerateExcercises generateExcercises;
    [SerializeField] private Button nextExerciseButton;
    public void openMenu()
    {
        menu.SetBool("isPressed", true);
    }

    public void closeMenu()
    {
        menu.SetBool("isPressed", false);
    }

    public void openLoseWeight()
    {
        loseWeight.SetBool("isPressed", true);
    }

    public void closeLoseWeight()
    {
        loseWeight.SetBool("isPressed", false);
    }

    public void startTraining()
    {
        if (!(generateExcercises.trainingsLeft == 0 || generateExcercises.trainingsLeftWeek == 0))
        {
            nextExerciseButton.interactable = true;
            loseWeight.SetBool("goBack", false);
            loseWeight.SetBool("isTraining", true);
        }
        else
        {
            StartCoroutine(wait());
        }
    }

    public void BackToLoseWeightMenu()
    {
        loseWeight.SetBool("goBack", true);
        loseWeight.SetBool("isTraining", false);
    }

    public void openHealthyFoodTab()
    {
        HealthyFood.SetBool("isStarted",true);
    }

    public void closeHealthyFoodTab()
    {
        HealthyFood.SetBool("isStarted",false);
    }


    IEnumerator wait()
    {
        generateExcercises.trainingsLeftDisplay.color = Color.red;
        generateExcercises.trainingsLeftWeekDisplay.color = Color.red;
        yield return new WaitForSeconds(1.05f);
        generateExcercises.trainingsLeftWeekDisplay.color = Color.white;
        generateExcercises.trainingsLeftDisplay.color = Color.white;
    }
}
