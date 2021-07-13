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

    private int index = 0;
    public bool isStarted = false;

    void Start()
    {
        StartCoroutine(wait());
    }

    void Update()
    {
        if (isStarted)
        {
            if (SwipeManager.swipeLeft)
            {
                pressPrev();
            }
            else if (SwipeManager.swipeRight)
            {
                pressNext();
            }
        }
    }

    public void pressNext()
    {
        index++;
        changeRecipe();
    }

    public void pressPrev()
    {
        index--;
        changeRecipe();
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
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(.3f);
        changeRecipe();
    }
}
