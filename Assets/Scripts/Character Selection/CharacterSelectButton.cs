using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using TMPro;

namespace Michsky.UI.Freebie
{
    public class CharacterSelectButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        [Header("CONTENT")]
        public int coinCount;
        public Sprite previewIcon;
        public Sprite characterIcon;
        public string characterName = "Character";
        public string characterType = "Support";
        public int characterID;
        [TextArea] public string characterInfo = "Character info here.";
        [TextArea] public string firstAbility = "First ability description here.";
        [TextArea] public string secondAbility = "Second ability description here.";
        [TextArea] public string thirdAbility = "Third ability description here.";
        
        public GameObject buyPanel;
        public GameObject noMoneyPanel;

        [Header("SOUND")]
        public bool enableButtonSounds = false;
        public bool useHoverSound = true;
        public bool useClickSound = true;
        public bool useSelectSound = true;
        public AudioClip hoverSound;
        public AudioClip clickSound;
        public AudioClip selectSound;
        public AudioSource soundSource;

        [Header("RESOURCES")]
        public Animator objectAnimator;
        public CharacterSelectManager characterManager;
        public Image previewImage;
        public TextMeshProUGUI characterText;
        public TextMeshProUGUI charAmt;

        [Header("SETTINGS")]
        public bool useCustomContent = false;

        [Header("EVENTS")]
        public UnityEvent onCharacterClick;
        public UnityEvent onCharacterSelection;

        void Start()
        {
            coinCount = PlayerPrefs.GetInt("CoinAmount", coinCount);
            if (useCustomContent == false)
        
                UpdateUI();
            if(GameStateManager.CharacterManager.gameCharacters[characterID].isUnlocked == true)
            {
                characterManager.enableSelecting = true;
            }
            else if(!GameStateManager.CharacterManager.gameCharacters[characterID].isUnlocked == true) {
                characterManager.enableSelecting = false;
            }
            Debug.Log("THISSSSSSSSSSSS OISSSSSSS THHHHHHHHHHHHHHEEEEEEEEE CUREEEEEEEEENT IID"+ characterID);
        
        
            
        }

        public void UpdateUI()
        {
            characterText.text = characterName;
            previewImage.sprite = previewIcon;
            charAmt.text = GameStateManager.CharacterManager.gameCharacters[characterID].characterAmount.ToString();
            if(GameStateManager.CharacterManager.gameCharacters[characterID].isUnlocked == true)
            {
                buyPanel.SetActive(false);
            }
            else{
                buyPanel.SetActive(true);
            }
            
        }
        public void BuyCharacter()
        {
            if(GameStateManager.CharacterManager.gameCharacters[characterID].characterAmount<coinCount)
            {
                coinCount -= GameStateManager.CharacterManager.gameCharacters[characterID].characterAmount;
                GameStateManager.CharacterManager.gameCharacters[characterID].isUnlocked = true;
                characterManager.enableSelecting = true;
                buyPanel.SetActive(false);
                
            }
            else{
                noMoneyPanel.SetActive(true);
            }
        }

        

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (!objectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pressed to Selected"))
            {
                objectAnimator.Play("Pressed to Selected");
                GameStateManager.CharacterManager.SelectCharacter(characterID);
                //GameStateManager.CharacterManager.OnBeginSelection.Raise();
                //GameStateManager.CharacterManager.OnSelected.Raise();
            }
            // if (enableButtonSounds == true && useHoverSound == true)
            //     soundSource.PlayOneShot(hoverSound);

            // if (!objectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hover to Pressed") &&
            //     !objectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pressed to Selected"))
            //     objectAnimator.Play("Normal to Hover");
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (!objectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Hover to Pressed") &&
                !objectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pressed to Selected"))
                objectAnimator.Play("Hover to Normal");
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            if (enableButtonSounds == true && useClickSound == true)
                soundSource.PlayOneShot(clickSound);

            if (!objectAnimator.GetCurrentAnimatorStateInfo(0).IsName("Pressed to Selected") &&
                characterManager.enableSelecting == true)
            {
                onCharacterClick.Invoke();
                objectAnimator.Play("Hover to Pressed");
            }

            if (characterManager != null)
            {
                if (characterManager.currentObjectAnimator != null)
                    if (characterManager.currentObjectAnimator != objectAnimator)
                        characterManager.UpdateCharacter();

                characterManager.currentObjectAnimator = objectAnimator;
                characterManager.UpdateInfo();
            }
        }
    }
}