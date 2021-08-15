using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class broadcastResult : MonoBehaviour, IPointerDownHandler
{
[SerializeField]
  private TextMeshProUGUI QuestionTxt;
    [SerializeField]
  private GameObject brodcastedSurveySprite;
    [SerializeField]
  private GameObject SurveySprite;
     public void OnPointerDown(PointerEventData eventData)
    {
      brodcastedSurveySprite.SetActive(true);
     brodcastedSurveySprite.GetComponent<RectTransform>().sizeDelta=new Vector2(brodcastedSurveySprite.GetComponent<RectTransform>().rect.width,SurveySprite.GetComponent<RectTransform>().rect.height+8);
   
    }
}
