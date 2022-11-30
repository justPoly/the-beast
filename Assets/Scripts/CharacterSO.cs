using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterSO", menuName = "CharacterSO/Characters")]
public class CharacterSO : ScriptableObject

{
    public GameObject prefabs;
    public string nameOfPlayer;
    public Sprite playerImage;
    public string speedOfPlayer;
}
