using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;
public class EndBroadcast : MonoBehaviour
// , IPointerDownHandler
{
    [SerializeField]
    private GameObject noSurveyText;
    [SerializeField]
    private GameObject endedSurveyText;
   
    [SerializeField]
    private GameObject Reponse;
    [SerializeField]
    private GameObject ResponseContainer;
    [SerializeField]
  private TextMeshProUGUI QuestionTxt;
  [SerializeField]
  private GameObject BroadcastResultButton;

  [SerializeField]
  private GameObject EndBroadcastResult;
    [SerializeField]
    private GameObject brodcastedSurveySprite;
  public void EndBroadcastSurvey()
    {

        if (ResponseContainer.transform.childCount!=0){
        Color grey;
        ColorUtility.TryParseHtmlString("#696969", out grey);
        QuestionTxt.GetComponent<TextMeshProUGUI>().color=grey;
        BroadcastResultButton.SetActive(true);
        EndBroadcastResult.SetActive(false);
        brodcastedSurveySprite.SetActive(false);

        }
        else{
        GameObject BroadcastResultButton=new GameObject();
        GameObject SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");
        GameObject[] Surveys = GameObject.FindGameObjectsWithTag("Survey");
        GameObject endedSurveyTxt=GameObject.Find(SurveyContainer.name+"/Ended survey Text (TMP)(Clone)");
        GameObject noSurveyTxt=GameObject.Find(SurveyContainer.name+"/No Survey Text (TMP)(Clone)");
        GameObject ActiveSurveyTxt=GameObject.Find(SurveyContainer.name+"/Active survey Text (TMP)");
        var posactiveSurveyTxt = ActiveSurveyTxt.transform.GetSiblingIndex();
        // Debug.Log(posactiveSurveyTxt);
        // SurveyContainer.transform.GetChild(posSurveyTxt-1).name.Equals("Active survey Text (TMP)");

        if ((noSurveyTxt==null && SurveyContainer.transform.childCount>2 && SurveyContainer.transform.GetChild(2).tag!="Survey") || SurveyContainer.transform.childCount==2 )
        {
        GameObject instanceNoSurveyText = Instantiate(noSurveyText);
        instanceNoSurveyText.transform.SetParent(SurveyContainer.transform,false);
        instanceNoSurveyText.transform.SetSiblingIndex(1);
        }
        if (endedSurveyTxt==null){
        GameObject instanceEndedSurveyText = Instantiate(endedSurveyText);
        instanceEndedSurveyText.transform.SetParent(SurveyContainer.transform,false); 
        }
      
        GameObject[] Options = GameObject.FindGameObjectsWithTag("Option");
        GameObject Survey = Instantiate( this.gameObject);
        Survey.tag="broadcastedSurvey";
        Destroy(this.gameObject);
        for (int i = 0; i < Survey.transform.childCount; i++)
        {
            if (!Survey.transform.GetChild(i).gameObject.activeSelf){
                if (Survey.transform.GetChild(i).gameObject.name.Equals("Broadcast Result Button")){
                     BroadcastResultButton=Survey.transform.GetChild(i).gameObject;
                }
            
            }
        }
        Survey.transform.SetParent(SurveyContainer.transform,false);
        GameObject BroadcastedSurveySprite = GameObject.Find(Survey.name+"/Brodcasted survey Image");
        GameObject BroadcastedTxt = GameObject.Find(Survey.name+"/Layout group Survey top/Broadcasted Text (TMP)");
        BroadcastedTxt.SetActive(true);
        GameObject LiveTxt = GameObject.Find(Survey.name+"/Layout group Survey top/Live Image");
        LiveTxt.SetActive(false);
        BroadcastedSurveySprite.SetActive(false);
        GameObject EndBroadcastButton = GameObject.Find(Survey.name+"/End Broadcast Button");
        EndBroadcastButton.SetActive(false);
        BroadcastResultButton.SetActive(true);
        GameObject OptionContainer = GameObject.Find(Survey.name+"/Options Container");
        GameObject ReponseContainer = GameObject.Find(Survey.name+"/Reponse Container");
      
        for (int i = 0; i < OptionContainer.transform.childCount; i++)
        {
            GameObject InstanceReponse = Instantiate(Reponse);
            InstanceReponse.name="Response"+UnityEngine.Random.Range(50, 100);
            InstanceReponse.transform.SetParent(ReponseContainer.transform,false);
            GameObject PourcentageTxt = GameObject.Find(InstanceReponse.name+"/Layout group/Pourcentage Text (TMP)");
            GameObject nbVotesTxt = GameObject.Find(InstanceReponse.name+"/Layout group/nbVotes Text (TMP)");
            GameObject OptionTxt = GameObject.Find(InstanceReponse.name+"/Option Text (TMP)");
            PourcentageTxt.GetComponent<TextMeshProUGUI>().text="0%";
            nbVotesTxt.GetComponent<TextMeshProUGUI>().text="0 votes";
            OptionTxt.GetComponent<TextMeshProUGUI>().text=OptionContainer.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text;
        } 
        OptionContainer.SetActive(false);
        // foreach (var opt in Options)
        // {
           
        // }
        
        }
       
       
       

      
    }
}
