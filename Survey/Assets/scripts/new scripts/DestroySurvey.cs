using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class DestroySurvey : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject Survey;
     [SerializeField]
    private GameObject noSurveyText;
    public void OnPointerDown(PointerEventData eventData)
    {
     
      Destroy(Survey);
      GameObject SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");  
      GameObject noSurveyTxt=GameObject.Find(SurveyContainer.name+"/No Survey Text (TMP)(Clone)");
      GameObject endedSurveyTxt=GameObject.Find(SurveyContainer.name+"/Ended survey Text (TMP)(Clone)");
      GameObject ActiveSurveyTxt=GameObject.Find(SurveyContainer.name+"/Active survey Text (TMP)");
      GameObject[] brodcastedSurveys=GameObject.FindGameObjectsWithTag("broadcastedSurvey");
      var posEndedSurveyTxt = endedSurveyTxt.transform.GetSiblingIndex();
       var posactiveSurveyTxt = ActiveSurveyTxt.transform.GetSiblingIndex();
      if (Survey.tag=="Survey"){
      if ((noSurveyTxt==null && SurveyContainer.transform.GetChild(posactiveSurveyTxt+1).tag!="Survey")|| Survey.transform.GetSiblingIndex()==posactiveSurveyTxt+1)
      {
        GameObject instanceNoSurveyText = Instantiate(noSurveyText);
        instanceNoSurveyText.transform.SetParent(SurveyContainer.transform,false);
        instanceNoSurveyText.transform.SetSiblingIndex(1);
      } 
      }
      else{
      if (endedSurveyTxt!=null  &&  brodcastedSurveys.Length==1 && Survey.transform.GetSiblingIndex()==posEndedSurveyTxt+1 ){
       Destroy(endedSurveyTxt);
      }
     
    
      }

    }
}
