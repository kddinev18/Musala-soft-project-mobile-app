using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator startButton;
    public void openMenu()
    {
        startButton.SetBool("isPressed", true);
    }

    public void closeMenu()
    {
        startButton.SetBool("isPressed", false);
    }
}
