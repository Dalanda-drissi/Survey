using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
using TMPro;
public class SurveyManager : MonoBehaviour
{

   
//     [SerializeField]
//     private GameObject endedSurveyText;
//     [SerializeField]
//    private GameObject broadcastedSurvey;
//     [SerializeField]
//    private GameObject ButtonEndBroadcast;
//        [SerializeField]
//    private GameObject ButtonBroadcast;
//     [SerializeField]
//    private GameObject OptionContainer;
//     [SerializeField]
//    private GameObject buttonBroadcastResult;
//    [SerializeField]
//    private GameObject responseContainer;
//     [SerializeField]
//     private GameObject Reponse;
    
//     private Rect rectTransformSurvey;
//     private Rect rectTransformBS;
//     private float heightSurvey; 
//      public static Rect SurveyStartRect;

 [SerializeField]
    private GameObject noSurveyText;
     private GameObject SurveyContainer;
    void Start(){
    SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");  
    if (SurveyContainer.transform.childCount==1){
     noSurveyText.SetActive(true);
    }
    else{
        noSurveyText.SetActive(false);
    }

    }
    void Update(){
        // SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");  
    if (SurveyContainer.transform.childCount==1){
     noSurveyText.SetActive(true);
    }
    else{
        noSurveyText.SetActive(false);
    }
    }
//  public void EndBroadcastSurvey()
//     {

        
//         GameObject BroadcastResultButton=new GameObject();
//         GameObject SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");
//         GameObject[] Surveys = GameObject.FindGameObjectsWithTag("Survey");
//         GameObject endedSurveyTxt=GameObject.Find(SurveyContainer.name+"/Ended survey Text (TMP)(Clone)");
//         GameObject noSurveyTxt=GameObject.Find(SurveyContainer.name+"/No Survey Text (TMP)(Clone)");
//         // GameObject ActiveSurveyTxt=GameObject.Find(SurveyContainer.name+"/Active survey Text (TMP)");
//         // var posactiveSurveyTxt = ActiveSurveyTxt.transform.GetSiblingIndex();
//         // Debug.Log(posactiveSurveyTxt);
//         // SurveyContainer.transform.GetChild(posSurveyTxt-1).name.Equals("Active survey Text (TMP)");
        
//         if (noSurveyTxt==null &&   SurveyContainer.transform.GetChild(2).tag!="Survey")
//         {
//         GameObject instanceNoSurveyText = Instantiate(noSurveyText);
//         instanceNoSurveyText.transform.SetParent(SurveyContainer.transform,false);
//         instanceNoSurveyText.transform.SetSiblingIndex(1);
//         }
//         if (endedSurveyTxt==null){
//         GameObject instanceEndedSurveyText = Instantiate(endedSurveyText);
//         instanceEndedSurveyText.transform.SetParent(SurveyContainer.transform,false); 
//         }
      
//         GameObject[] Options = GameObject.FindGameObjectsWithTag("Option");
//         GameObject Survey = Instantiate( this.gameObject);
//         Survey.tag="broadcastedSurvey";
//         Destroy(this.gameObject);
//         for (int i = 0; i < Survey.transform.childCount; i++)
//         {
//             if (!Survey.transform.GetChild(i).gameObject.activeSelf){
//                 if (Survey.transform.GetChild(i).gameObject.name.Equals("Broadcast Result Button")){
//                      BroadcastResultButton=Survey.transform.GetChild(i).gameObject;
//                 }
            
//             }
//         }
//         Survey.transform.SetParent(SurveyContainer.transform,false);
//         GameObject BroadcastedSurveySprite = GameObject.Find(Survey.name+"/Brodcasted survey Image");
//         GameObject BroadcastedTxt = GameObject.Find(Survey.name+"/Layout group Survey top/Broadcasted Text (TMP)");
//         BroadcastedTxt.SetActive(true);
//         GameObject LiveTxt = GameObject.Find(Survey.name+"/Layout group Survey top/Live Image");
//         LiveTxt.SetActive(false);
//         BroadcastedSurveySprite.SetActive(false);
//         // GameObject EndBroadcastButton = GameObject.Find(Survey.name+"/End Broadcast Button");
//         ButtonEndBroadcast.SetActive(false);
//         BroadcastResultButton.SetActive(true);
//         // GameObject OptionContainer = GameObject.Find(Survey.name+"/Options Container");
//         // GameObject ReponseContainer = GameObject.Find(Survey.name+"/Reponse Container");
      
//         for (int i = 0; i < OptionContainer.transform.childCount; i++)
//         {
           
//             GameObject InstanceReponse = Instantiate(Reponse);
//             InstanceReponse.name="Response"+UnityEngine.Random.Range(50, 100);
//             InstanceReponse.transform.SetParent(responseContainer.transform,false);
//             GameObject PourcentageTxt = GameObject.Find(InstanceReponse.name+"/Layout group/Pourcentage Text (TMP)");
//             GameObject nbVotesTxt = GameObject.Find(InstanceReponse.name+"/Layout group/nbVotes Text (TMP)");
//             GameObject OptionTxt = GameObject.Find(InstanceReponse.name+"/Option Text (TMP)");
//             PourcentageTxt.GetComponent<TextMeshProUGUI>().text="0%";
//             nbVotesTxt.GetComponent<TextMeshProUGUI>().text="0 votes";
//             OptionTxt.GetComponent<TextMeshProUGUI>().text=OptionContainer.transform.GetChild(i).GetComponent<TextMeshProUGUI>().text;
//         } 
//         OptionContainer.SetActive(false);
//         responseContainer.SetActive(true);
//         // foreach (var opt in Options)
//         // {
           
//         // }
        
       
       

      
//     }
//     public void DestroySurvey(){
//       Destroy(this.gameObject);
//       GameObject SurveyContainer = GameObject.FindGameObjectWithTag("SurveyContainer");  
//       GameObject noSurveyTxt=GameObject.Find(SurveyContainer.name+"/No Survey Text (TMP)(Clone)");
//       GameObject endedSurveyTxt=GameObject.Find(SurveyContainer.name+"/Ended survey Text (TMP)(Clone)");
//       GameObject ActiveSurveyTxt=GameObject.Find(SurveyContainer.name+"/Active survey Text (TMP)");
//       GameObject[] brodcastedSurveys=GameObject.FindGameObjectsWithTag("broadcastedSurvey");
//       var posEndedSurveyTxt = endedSurveyTxt.transform.GetSiblingIndex();
//        var posactiveSurveyTxt = ActiveSurveyTxt.transform.GetSiblingIndex();
//       if (this.gameObject.tag=="Survey"){
//       if ((noSurveyTxt==null && SurveyContainer.transform.GetChild(posactiveSurveyTxt+1).tag!="Survey")|| this.gameObject.transform.GetSiblingIndex()==posactiveSurveyTxt+1)
//       {
//         GameObject instanceNoSurveyText = Instantiate(noSurveyText);
//         instanceNoSurveyText.transform.SetParent(SurveyContainer.transform,false);
//         instanceNoSurveyText.transform.SetSiblingIndex(1);
//       } 
//       }
//       else{
//       if (endedSurveyTxt!=null  &&  brodcastedSurveys.Length==1 && this.gameObject.transform.GetSiblingIndex()==posEndedSurveyTxt+1 ){
//        Destroy(endedSurveyTxt);
//       }
     
    
//       }

//     }
//      public void MaximisePanel()
//     {
//     rectTransformBS=BroadCastSurvey.SurveyStartRect;
//     broadcastedSurvey.GetComponent<RectTransform>().sizeDelta=new Vector2(broadcastedSurvey.GetComponent<RectTransform>().rect.width,rectTransformBS.height);
   
//      if (broadcastedSurvey.activeSelf){
         
//         ButtonEndBroadcast.SetActive(true);
//         OptionContainer.SetActive(true);
//         //   responseContainer.SetActive(false);
//      }    
//      else{
//          ButtonBroadcast.SetActive(true);
//           OptionContainer.SetActive(true);
//           responseContainer.SetActive(false);
//      }
//      if (responseContainer.transform.childCount!=0){
//            buttonBroadcastResult.SetActive(true);
//            ButtonBroadcast.SetActive(false);
//            responseContainer.SetActive(true);
//            OptionContainer.SetActive(false);

//          }
    
//     }
//     public void MinimisePanel()
//     {
//          if (broadcastedSurvey.activeSelf){
         
//         ButtonEndBroadcast.SetActive(false);
//         OptionContainer.SetActive(false);
//         //   responseContainer.SetActive(false);
//      }    
//      else{
//          broadcastedSurvey.SetActive(false);
//          ButtonBroadcast.SetActive(false);
//           OptionContainer.SetActive(false);
//         //   responseContainer.SetActive(false);
//      }
//      if (responseContainer.transform.childCount!=0){
//            buttonBroadcastResult.SetActive(false);
//            ButtonBroadcast.SetActive(false);
//            responseContainer.SetActive(false);
//            OptionContainer.SetActive(false);

//          }
//         // responseContainer.SetActive(false);
//         // buttonBroadcastResult.SetActive(false);
//     // var heightSurvey = LayoutUtility.GetPreferredHeight(this.gameObject.GetComponent<RectTransform>())-150f;
//     // this.GetComponent<RectTransform>().sizeDelta=new Vector2(rectTransformSurvey.width,heightSurvey);
//     // Debug.Log(heightSurvey);
//     broadcastedSurvey.GetComponent<RectTransform>().sizeDelta=new Vector2(broadcastedSurvey.GetComponent<RectTransform>().rect.width,112);
//     }

// public void BroadcastSurvey()
//     {
//     broadcastedSurvey.SetActive(true);
//     broadcastedSurvey.GetComponent<RectTransform>().sizeDelta=new Vector2(broadcastedSurvey.GetComponent<RectTransform>().rect.width,this.gameObject.GetComponent<RectTransform>().rect.height+30);
//     SurveyStartRect.width=broadcastedSurvey.GetComponent<RectTransform>().rect.width;
//     SurveyStartRect.height=this.gameObject.GetComponent<RectTransform>().rect.height+30;
//     // Color grey;
//     // ColorUtility.TryParseHtmlString("#696969", out grey);
//     // QuestionTxt.GetComponent<TextMeshProUGUI>().color=grey;
//     }



    // [SerializeField]
    // private GameObject ExistTxt;
    // [SerializeField]
    // private GameObject Survey;
    // [SerializeField]
    // private GameObject Option;
    // [SerializeField]
    // private GameObject Container;
    // private string id;
    // private string nbUsers;
    // public static List<Options> Options=new List<Options>();
    
    // void Start()
    // {
    //     id = UserInfo.id;
       
    //     StartCoroutine(GetAllUsers());
    //     StartCoroutine(GetQuestionList(id));

    // }

    //     void Update()
    // {
      

    // }

    // private IEnumerator GetAllUsers(){
    //    UnityWebRequest Users = UnityWebRequest.Get("http://localhost:4000/User/");
    //    yield return Users.SendWebRequest();
    //    nbUsers=Users.downloadHandler.text;
    // }
    // private IEnumerator GetQuestionList(string id){
    
    //  UnityWebRequest questionList = UnityWebRequest.Get("http://localhost:4000/Question/readByIdUser/"+id);
    //  yield return questionList.SendWebRequest();
    //   if (questionList.isNetworkError || questionList.isHttpError)
    //     {    
    //         Debug.Log(questionList.error);
            
    //     }
    //     else
    //     {
            
    //         var QuestionList = JsonUtility.FromJson<ListQuestions>("{\"Questions\":" + questionList.downloadHandler.text + "}");
    //         if (questionList.downloadHandler.text=="[]"){
    //             ExistTxt.SetActive(true);
    //         }
    //         else{
    //            ExistTxt.SetActive(false);
    //         }
    //         for (int i = 0; i < QuestionList.Questions.Length; i++)
    //         {
            
    //             GameObject SurveyGO= Instantiate(Survey);
    //             SurveyGO.name=QuestionList.Questions[i].Label;
    //             SurveyGO.transform.SetParent(Container.transform);
    //             GameObject Questiontxt = GameObject.Find(SurveyGO.name+"/QuestionMain/QuestionTxt");
    //             Questiontxt.GetComponent<Text>().text=QuestionList.Questions[i].QuestionTxt;
    //             GameObject OptionContainer = GameObject.Find(SurveyGO.name+"/Content/Scroll View/Viewport/Content");
    //                 foreach (var item in QuestionList.Questions[i].OptionsList)
    //                 {
    //                     GameObject OptionGO= Instantiate(Option);
    //                     Debug.Log(item.Label);
    //                     OptionGO.name=item.Label;
    //                     OptionGO.transform.SetParent(OptionContainer.transform);
    //                     GameObject Optiontxt = GameObject.Find(OptionGO.name+"/OptionTxt");
    //                     Optiontxt.GetComponent<Text>().text=item.OptionTxt;
    //                     float pourcentage=0;
    //                     if (int.Parse(item.NBVote)!=0){
                           
    //                         pourcentage = (float.Parse(item.NBVote, System.Globalization.CultureInfo.InvariantCulture) * 100 ) / float.Parse(nbUsers, System.Globalization.CultureInfo.InvariantCulture);
    //                     }
    //                     GameObject PecentageTxt = GameObject.Find(OptionGO.name+"/PecentageTxt");
    //                     PecentageTxt.GetComponent<Text>().text=pourcentage.ToString()+"%";
    //                     GameObject progressBar = GameObject.Find(OptionGO.name+"/progressBar");
    //                     progressBar.GetComponent<Slider>().value=pourcentage;
    //                     GameObject NBVoteTxt = GameObject.Find(OptionGO.name+"/NBVoteTxt");
    //                     NBVoteTxt.GetComponent<Text>().text=item.NBVote.ToString()+"Votes";

    //                 }
          

    //         }
            
         

    //     }
    // }




   
}
