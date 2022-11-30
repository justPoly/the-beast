using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CharacterManager : MonoBehaviour
{
    public CharacterSO[] characters;
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI characterSpeed;
    public Image characterImage;
    public int characterIndex =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(CharacterSO g in characters)
        {
            Debug.Log(g);
        }
        
    }
    public void NextCharacter()
    {
        
        for(int i = 0; i<=characters.Length; i++)
        {
            characterIndex++;
            if(i>=characters.Length)
            {
                characterIndex = 1;
                characterName.text = characters[characterIndex].nameOfPlayer;
                characterSpeed.text = characters[characterIndex].speedOfPlayer;
            }
            
            
        }
        
        

        
        
    }
}
