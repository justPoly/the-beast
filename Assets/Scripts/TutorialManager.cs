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
    //public GameObject hand;
    public GameObject nextButton;
    public GameObject prevButton;

    public int currentIndex;
    public GameObject tutuorialPanel;

    // Start is called before the first frame update

    private void Awake()
    {
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
        //LeanTween.moveLocal(gameObject.transform.GetChild(1).gameObject, Vector3.zero, 1.5f).setEase(LeanTweenType.easeInOutBack);
        currentIndex = -1;
        //tutorialText.GetComponent<RectTransform>().localScale = Vector3.zero;
        Invoke("ChangeNext", 1.6f);
        //nextButton.GetComponent<RectTransform>().localScale = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        
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