using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class ShowHideContent : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject dropdownArraw;
     [SerializeField]
    private GameObject UpArraw;
     [SerializeField]
    private GameObject Content;
     [SerializeField]
    private GameObject QuestionTxt;
  
    private bool buttonPressed ;
    private GameObject SurveyContainer;
    void Start(){
        SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(buttonPressed)
        {
            buttonPressed = false;
            Content.SetActive(false);
            dropdownArraw.SetActive(true);
            UpArraw.SetActive(false);
            QuestionTxt.GetComponent<Text>().color=Color.blue;
          
        }
        else 
        {
            buttonPressed = true;
            Content.SetActive(true);
            dropdownArraw.SetActive(false);
            UpArraw.SetActive(true);
            QuestionTxt.GetComponent<Text>().color=Color.gray;
           
        }
    }
    
    
}
