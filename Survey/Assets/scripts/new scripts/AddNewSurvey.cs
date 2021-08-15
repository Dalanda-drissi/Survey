using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class AddNewSurvey : MonoBehaviour
{
  [SerializeField]
  private GameObject buttonCreate;
    [SerializeField]
    private GameObject Survey;
     [SerializeField]
    private GameObject Option;
    [SerializeField]
    private GameObject SurveyContainer  ;
    [SerializeField]
    private GameObject Question;
    [SerializeField]
    private GameObject OptionInputField1;
[SerializeField]
    private GameObject OptionInputField2;

    [SerializeField]
    private GameObject errorTxtQuestion;
    [SerializeField]
    private GameObject errorTxtOption;
    
    private  GameObject [] OptList ;
    private  string QuestionTxt;
    void Start(){
    //  buttonCreate.GetComponent<Button>().interactable=false;
    
    }
    void Update(){
      OptList = GameObject.FindGameObjectsWithTag("Option");
      
    }
    public void Vider(){
     Question.GetComponent<TMP_InputField>().text="";
     OptList = GameObject.FindGameObjectsWithTag("Option");
     foreach (var item in OptList)
     {
         if (!item.name.Equals("InputField options clone 1") && !item.name.Equals("InputField options clone 2"))
         {
           Destroy(item);
         }
         else{
             item.GetComponent<TMP_InputField>().text="";
         }
     }
    }
    public void create(){ 
      
      GameObject noSurveyTxt = GameObject.FindGameObjectWithTag("noSurveyTxt");
      
      if (noSurveyTxt!=null){
         Destroy(noSurveyTxt);
      }
      QuestionTxt =Question.GetComponent<TMP_InputField>().text;
      OptList = GameObject.FindGameObjectsWithTag("Option");
      if (QuestionTxt.Length==0){
      errorTxtQuestion.SetActive(true);
      }
      else{
        errorTxtQuestion.SetActive(false);
      }
      if (OptionInputField1.GetComponent<TMP_InputField>().text.Length==0 || OptionInputField2.GetComponent<TMP_InputField>().text.Length==0){
        errorTxtOption.SetActive(true);
      }
      else{
        errorTxtOption.SetActive(false);
      }
      if (QuestionTxt.Length!=0 && OptionInputField1.GetComponent<TMP_InputField>().text.Length!=0 && OptionInputField2.GetComponent<TMP_InputField>().text.Length!=0  ){
      GameObject instanceSurvey = Instantiate(Survey);
      
      instanceSurvey.name="Survey"+UnityEngine.Random.Range(50, 100);
      instanceSurvey.tag="Survey";
     
      instanceSurvey.transform.SetParent(SurveyContainer.transform,false);
      instanceSurvey.transform.SetSiblingIndex(1);
      GameObject QuestionSurvey = GameObject.Find(instanceSurvey.name+"/Layout group Survey top/Question Text (TMP)");
      QuestionSurvey.GetComponent<TextMeshProUGUI>().text=QuestionTxt;
       
      GameObject OptionsContainer = GameObject.Find(instanceSurvey.name+"/Options Container");
      
       if (OptList!=null){
         
        foreach(GameObject Opt in OptList)
        {
              if (Opt.GetComponent<TMP_InputField>().text.Length!=0){
              GameObject InstanceOption = Instantiate(Option);
              // InstanceOption.tag="Option";
              InstanceOption.name="Option"+UnityEngine.Random.Range(50, 100);
              InstanceOption.transform.SetParent(OptionsContainer.transform,false);
           
              InstanceOption.GetComponent<TextMeshProUGUI>().text=Opt.GetComponent<TMP_InputField>().text;
              }
             
            // //   GameObject OptionSurvey = GameObject.Find(instanceSurvey.name+"/Options Container/"+InstanceOption.name);  
          
        }

    Vider();
    }
    else {
        Debug.Log("option null");
    }
      }
     
    }
}
