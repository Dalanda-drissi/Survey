using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class BroadCastSurvey : MonoBehaviour, IPointerDownHandler
{
  [SerializeField]
  private GameObject brodcastedSurveySprite;
   [SerializeField]
  private GameObject SurveySprite;
  
  public static Rect SurveyStartRect;
  
     public void OnPointerDown(PointerEventData eventData)
    {
    brodcastedSurveySprite.SetActive(true);
    brodcastedSurveySprite.GetComponent<RectTransform>().sizeDelta=new Vector2(brodcastedSurveySprite.GetComponent<RectTransform>().rect.width,SurveySprite.GetComponent<RectTransform>().rect.height+30);
    SurveyStartRect.width=brodcastedSurveySprite.GetComponent<RectTransform>().rect.width;
    SurveyStartRect.height=SurveySprite.GetComponent<RectTransform>().rect.height+30;
    
    }
    
}
