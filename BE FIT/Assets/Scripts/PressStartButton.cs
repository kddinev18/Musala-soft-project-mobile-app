using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public Animator anim;

    public void PressStart()
    {
        anim.SetBool("PressButton", true);
    }
}
