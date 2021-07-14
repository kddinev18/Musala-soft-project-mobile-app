using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator menu;
    [SerializeField] private Animator loseWeight;
    [SerializeField] private Animator healthyFood;
    [SerializeField] private Animator fitnessSchedule;
    [SerializeField] private GenerateExcercises generateExcercises;
    [SerializeField] private Button nextExerciseButton;
    [SerializeField] private HealthyFoodButtons healthyFoodButtons;

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
        if (!(generateExcercises.trainingsLeft == 0))
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
        healthyFood.SetBool("isStarted",true);
        healthyFoodButtons.isStarted = true;
    }

    public void closeHealthyFoodTab()
    {
        healthyFood.SetBool("isStarted",false);
    }

    public void openFitnessSchedule()
    {
        fitnessSchedule.SetBool("isStarted", true);
    }

    public void closeFitnessSchedule()
    {
        fitnessSchedule.SetBool("isStarted", false);
    }

    IEnumerator wait()
    {
        generateExcercises.trainingsLeftDisplay.color = Color.red;
        yield return new WaitForSeconds(1.05f);
        generateExcercises.trainingsLeftDisplay.color = Color.white;
    }
}
