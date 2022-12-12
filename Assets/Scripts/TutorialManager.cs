using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{ 
    public TutorialSO tutorials;
    public TextMeshProUGUI tutorialText;
    public TextMeshProUGUI Text;
    public TextMeshProUGUI buttonText;
    public GameObject hand;
    public GameObject nextButton;
    public GameObject prevButton;

    public int currentIndex;
    public GameObject tutuorialPanel;
    public bool canJump;
    

    public static TutorialManager instance;

    private void Awake()
    {
        instance = this;
        //PlayerPrefs.SetInt("FirstTime", 0);
        

        if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1)
        {
            Debug.Log("First Time Opening");

            //Set first time opening to false
            PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);
            tutuorialPanel.SetActive(true);
            

        }
        else
        {
            Debug.Log("NOT First Time Opening");

            tutuorialPanel.SetActive(false);
        }
        //PlayerPrefs.DeleteAll();
                
    }

    void Start()
    {
        
        //tutorialText.GetComponent<RectTransform>().localScale = Vector3.zero;
        InvokeUI();
        Invoke("DisableUI", 4f);
        
        
        //nextButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InvokeUI()
    {
        canJump = false;
        if(SceneFader.instance.isSceneFaded == true)
        {    

            Invoke("UIUpdate", 1.2f);
            
            Invoke("Tween", 1.2f);
            

            
        }
    }
    public void UIUpdate()
    {
        tutorialText.gameObject.SetActive(true);
        tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();
        canJump = true;
    }
    public void DisableUI()
    {
        tutuorialPanel.SetActive(false);
    }
    public void Tween()
    {
        hand.SetActive(true);
        LeanTween.cancel(hand);
        transform.localScale = Vector3.one;
        LeanTween.scale(hand, Vector3.one * 2, 2f).setEasePunch();
        canJump = true;
    }





    
    public void ChangeNext()
    {
        /*for(int i = 0; i<=tutorials.tutorial_Instructions.Length; i++)
        {*/

        currentIndex++;
            
            
            if (currentIndex == tutorials.tutorial_Instructions.Length)
            {
                //GameManager.instance.EndTutorial();
                tutuorialPanel.SetActive(false);
            }
            if (currentIndex == tutorials.tutorial_Instructions.Length - 1)
            {
                currentIndex = 3;
                Text.text = "Continue";


                prevButton.SetActive(true);
                

                
                
            }
            tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();

            
            

    }
    public void DeactivateTutorial()
    {
        tutuorialPanel.SetActive(false);
    }
    public void ChangePrevious()
    {
        currentIndex--;
        if (currentIndex < 0)
                
        {    currentIndex = 0; 
        }

        tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();
        

        
    }

    /*public IEnumerator HandAnimation()
    {
        while (true)
        {
            LeanTween.moveLocal(hand, new Vector3(506, hand.GetComponent<RectTransform>().localPosition.y, 0), 1.5f).setEase(LeanTweenType.easeInOutQuint);
            yield return new WaitForSeconds(1.6f);
            LeanTween.moveLocal(hand, new Vector3(66, hand.GetComponent<RectTransform>().localPosition.y, 0), 1.0f).setEase(LeanTweenType.easeInOutQuint);
            yield return new WaitForSeconds(1.6f);
        }
    }*/
}