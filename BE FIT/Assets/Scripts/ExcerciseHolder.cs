using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class ExcerciseHolder : MonoBehaviour
{
    public string[] excercises;
    public string[] description;
    public string[] time;

    void Start()
    {
        excercises = File.ReadAllLines("Assets\\Data Files\\ExcerciseNameData.txt").ToArray();
        description = File.ReadAllLines("Assets\\Data Files\\ExcerciseDescriptionData.txt").ToArray();
        time = File.ReadAllLines("Assets\\Data Files\\ExcerciseTimeData.txt").ToArray();
    }

}
