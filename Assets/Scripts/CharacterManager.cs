using UnityEngine;

[CreateAssetMenu(fileName = "CharacterManager", menuName = "Managers/Character Manager")]
public class CharacterManager : ScriptableObject
{

    [FancyHeader(" CHARACTER MANAGER ", 1.5f, "violet", 5.5f, order = 0)]

    public Characters[] gameCharacters;
    public int currentSelected;

    [Header("Selection Events")]
    public GameEvent OnBeginSelection;
    public GameEvent OnSelected;


    public void InitializeCharacter()
    {
        currentSelected = PlayerPrefs.GetInt("selectedCharacter");
    }


    public int SelectCharacter(int id)
    {
        PlayerPrefs.SetInt("selectedCharacter", id);
        return currentSelected = id;
    }
}
