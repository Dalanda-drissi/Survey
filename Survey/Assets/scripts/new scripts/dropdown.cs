using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class dropdown : MonoBehaviour
{
  [SerializeField]
   private GameObject BroadcastResultButton;
   [SerializeField]
   private GameObject broadcastedSurvey;
    [SerializeField]
   private GameObject ButtonEndBroadcast;
       [SerializeField]
   private GameObject ButtonBroadcast;
    [SerializeField]
   private GameObject OptionContainer;
    [SerializeField]
   private GameObject buttonBroadcastResult;
   [SerializeField]
   private GameObject responseContainer;
    private Rect rectTransformSurvey;
    private Rect rectTransformBS;
    private float heightSurvey; 

    void Start()
    {
        
    rectTransformSurvey=this.GetComponent<RectTransform>().rect;
    
    }
   void Update(){
     heightSurvey = LayoutUtility.GetPreferredHeight(this.gameObject.GetComponent<RectTransform>());
     broadcastedSurvey.GetComponent<RectTransform>().sizeDelta=new Vector2(broadcastedSurvey.GetComponent<RectTransform>().rect.width,heightSurvey+2);
    
   }
   
    public void MaximisePanel()
    {
    rectTransformBS=BroadCastSurvey.SurveyStartRect;

     if (broadcastedSurvey.activeSelf){
          if (responseContainer.transform.childCount!=0){
           buttonBroadcastResult.SetActive(false);
           ButtonBroadcast.SetActive(false);
           responseContainer.SetActive(true);
           OptionContainer.SetActive(false);
               ButtonEndBroadcast.SetActive(true);
         }
         else{
             ButtonEndBroadcast.SetActive(true);
              OptionContainer.SetActive(true);
         }
       
     }    
     else{
 if (responseContainer.transform.childCount!=0){
           buttonBroadcastResult.SetActive(true);
           ButtonBroadcast.SetActive(false);
           responseContainer.SetActive(true);
           OptionContainer.SetActive(false);

         }
         else{
            ButtonBroadcast.SetActive(true);
          OptionContainer.SetActive(true);
          responseContainer.SetActive(false);
         }
         
     }
    
    
    }
    public void MinimisePanel()
    {
         if (broadcastedSurvey.activeSelf){
         
        ButtonEndBroadcast.SetActive(false);
        OptionContainer.SetActive(false);
        
     }    
     else{
         broadcastedSurvey.SetActive(false);
         ButtonBroadcast.SetActive(false);
          OptionContainer.SetActive(false);
       
     }
     if (responseContainer.transform.childCount!=0){
           buttonBroadcastResult.SetActive(false);
           ButtonBroadcast.SetActive(false);
           responseContainer.SetActive(false);
           OptionContainer.SetActive(false);

         }
        
    
    }
}
