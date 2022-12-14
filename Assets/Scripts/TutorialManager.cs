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
    public GameObject contButton;

    public int currentIndex;
    public GameObject tutuorialPanel;
    public bool canJump;
    

    public static TutorialManager instance;

    private void Awake()
    {
        instance = this;
        //PlayerPrefs.SetInt("FirstTime", 0);
        
                        
    }

    void Start()
    {
        PlayerPrefs.DeleteAll();
        tutorialText.text = tutorials.tutorial_Instructions[0].ToString();
        int amtOfGameplays = PlayerPrefs.GetInt("FIRSTTIMEOPENING");
        Debug.Log("tutorials.tutorial_Instructions.Length " + tutorials.tutorial_Instructions.Length);
        if(amtOfGameplays == 0)
        {
            
            Invoke("InvokeUI", 1.5f);



            
            if(GameManager.instance.isGameOver == true)
            {
                tutuorialPanel.SetActive(false);
            }
            
            
        } 
        else
        {
                tutuorialPanel.SetActive(false);
        } 

        
        

        
        
        
        //nextButton.GetComponent<RectTransform>().localScale = Vector3.zero;
        
    }

    // Update is called once per frame
    void Update()
    {

        
         
        //tutorialText.GetComponent<RectTransform>().localScale = Vector3.zero;
        //Debug.Log("amtOfGameplays check am ooooo" + amtOfGameplays);
        
    }
    public void InvokeUI()
    {
        tutuorialPanel.SetActive(true);
        Time.timeScale = 0;
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
    }
    public void UIUpdate()
    {
        tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();
        
    }
    public void DisableUI()
    {
        tutuorialPanel.SetActive(false);
        Time.timeScale = 1;
    }
    public void Tween()
    {
        
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
   
        
        if (currentIndex >= tutorials.tutorial_Instructions.Length)
        {
            currentIndex = 4;
            contButton.SetActive(true);
            nextButton.SetActive(false);
            

                

                
                
        }
        tutorialText.text = tutorials.tutorial_Instructions[currentIndex].ToString();

            
            

    }
    public void DeactivateTutorial()
    {
        tutuorialPanel.SetActive(false);
        Time.timeScale = 1;
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