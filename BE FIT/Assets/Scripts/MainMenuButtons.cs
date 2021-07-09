using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuButtons : MonoBehaviour
{
    [SerializeField] private Animator menu;
    [SerializeField] private Animator loseWeight;
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
}
