using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Animator startButton;
    [SerializeField] private Animator SceneTrasition;
    [SerializeField] private int index;

    public void pressStart()
    {
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        startButton.SetBool("PressButton", true);
        yield return new WaitForSeconds(1f);
        SceneTrasition.SetBool("EndScene", true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + index);
    }
}
