using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tutorial", menuName = "Tutorial/New Tutorial")]
public class TutorialSO : ScriptableObject
{
    public string[] tutorial_Instructions;
}