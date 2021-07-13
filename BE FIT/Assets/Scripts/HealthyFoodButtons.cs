using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthyFoodButtons : MonoBehaviour
{
    [SerializeField] private Animator nextPrevRecipe;
    [SerializeField] private Button nextButton;
    [SerializeField] private DataHolder healthyFoodHolder;

    [SerializeField] private Text Name;
    [SerializeField] private Text Desc;
    [SerializeField] private Text Calories;
    [SerializeField] private Text Time;

    private int index = 0;

    void Start()
    {
        StartCoroutine(wait());
    }

    public void pressNext()
    {
        index++;
        StartCoroutine(wait());
    }

    public void pressPrev()
    {
        index--;
        StartCoroutine(wait());
    }

    private void changeRecipe()
    {
        if(index > healthyFoodHolder.healthyFoodName.Length-1)
        {
            index = 0;
        }
        else if(index < 0)
        {
            index = healthyFoodHolder.healthyFoodName.Length-1;
        }
        Name.text = healthyFoodHolder.healthyFoodName[index];
        Desc.text = healthyFoodHolder.healthyFoodDesc[index];
        Calories.text = healthyFoodHolder.healthyFoodCalories[index];
        Time.text = healthyFoodHolder.healthyFoodTime[index];
    }

    IEnumerator wait()
    {
        nextPrevRecipe.SetBool("newRecipe", true);
        yield return new WaitForSeconds(.25f);
        nextPrevRecipe.SetBool("newRecipe", false);
        changeRecipe();
    }
}
