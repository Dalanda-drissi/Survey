using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SurveysManager : MonoBehaviour
{
     [SerializeField]
    private GameObject noSurveyText;
    private  GameObject SurveyContainer;
    void Start()
    {
      
    }

    
    void Update()
    {
       SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");  
      GameObject noSurveyTxt=GameObject.Find(SurveyContainer.name+"/No Survey Text (TMP)(Clone)");
      if (noSurveyTxt==null && SurveyContainer.transform.GetChild(2).name.IndexOf("Survey")<0)
      {
        GameObject instanceNoSurveyText = Instantiate(noSurveyText);
        instanceNoSurveyText.transform.SetParent(SurveyContainer.transform,false);
        instanceNoSurveyText.transform.SetSiblingIndex(1);
      } 
    }
}
