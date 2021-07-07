using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Animator startButton;
    [SerializeField] private Animator sceneTrasition;
    [SerializeField] private Animator menuAnimation;
    [SerializeField] private int index;
    private bool isPressedBefore = false; 

    public void pressStart()
    {
        StartCoroutine(wait());
    }

    public void pressMenu()
    {
        if (!isPressedBefore)
        {
            menuAnimation.SetBool("PressMenuButton", true);
            isPressedBefore = true;
        }
        else if(isPressedBefore)
        {
            menuAnimation.SetBool("PressMenuButton", false);
            isPressedBefore = false;
        }
    }

    IEnumerator wait()
    {
        startButton.SetBool("PressButton", true);
        yield return new WaitForSeconds(1f);
        sceneTrasition.SetBool("EndScene", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
