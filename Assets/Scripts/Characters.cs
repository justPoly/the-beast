using NaughtyAttributes;
using UnityEngine;
[CreateAssetMenu(menuName = "Character/NewCharcter")]
public class Characters : ScriptableObject
{
    [FancyHeader("NEW CHARATCER", 3f, "#D4AF37", 8.5f, order = 0)]
    [Space]
    public string charName;
    [Space]
    public bool isUnlocked;
    [Space]
    public int characterAmount;
    [Space]
    [ShowAssetPreview]
    public GameObject playerPrefab;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
