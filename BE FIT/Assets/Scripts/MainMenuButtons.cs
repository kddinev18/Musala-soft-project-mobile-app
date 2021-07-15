using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator menu;
    [SerializeField] private Animator healthyFood;
    [SerializeField] private Animator stats;
    [SerializeField] private GenerateExcercises generateExcercises;
    [SerializeField] private Button nextExerciseButton;
    [SerializeField] private HealthyFoodButtons healthyFoodButtons;
    [SerializeField] private Animator loseWeight;
    private bool pressedBefore = false;

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

    public void BackToLoseWeightMenu()
    {
        if(!generateExcercises.isTrainingDone)
        {
            generateExcercises.trainingsLeft--;
            generateExcercises.trainingsLeftDisplay.text = generateExcercises.trainingsLeft.ToString();
            SaveSystem.saveUserData(generateExcercises);
        }
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

    public void openCloseStats()
    {
        if(!pressedBefore)
        {
            stats.SetBool("isStarted", true);
            pressedBefore = true;
        }
        else
        {
            stats.SetBool("isStarted", false);
            pressedBefore = false;
        }

    }

    IEnumerator wait()
    {
        generateExcercises.trainingsLeftDisplay.color = Color.red;
        yield return new WaitForSeconds(1.05f);
        generateExcercises.trainingsLeftDisplay.color = Color.white;
    }
}
