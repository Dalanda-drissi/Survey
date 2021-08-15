using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class AddOption : MonoBehaviour
// , IPointerDownHandler
{
  [SerializeField]
    private TMP_InputField QuestionField;
    [SerializeField]
    private GameObject OptionField;
    [SerializeField]
    private GameObject OptionsContainer;
    [SerializeField]
    private Sprite disabledButtonSprite;
    [SerializeField]
    private GameObject buttonAddOption;
    private Sprite currentSprite;
    private Color currentColor;
    [SerializeField]
    private GameObject infoTxt;
     [SerializeField]
    private GameObject OptionInputField1;
    [SerializeField]
    private GameObject OptionInputField2;
    [SerializeField]
    private GameObject errorTxtOption;
    void Start(){
     currentSprite= buttonAddOption.GetComponent<Image>().sprite;
     currentColor = buttonAddOption.GetComponent<Image>().color;
    }
    void Update()
    {
        if (OptionsContainer.transform.childCount>=5)
         {
           
          buttonAddOption.GetComponent<Image>().color=Color.white;
          buttonAddOption.SetActive(false);
          buttonAddOption.GetComponent<Image>().sprite=disabledButtonSprite;
          infoTxt.SetActive(true);


         }
         else{
          buttonAddOption.SetActive(true);
           buttonAddOption.GetComponent<Image>().sprite=currentSprite;
           buttonAddOption.GetComponent<Image>().color=currentColor;
           infoTxt.SetActive(false);
         }
        
    }
    public void AddNewOption()
    {
      if (OptionsContainer.transform.childCount<5){
        if (OptionInputField1.GetComponent<TMP_InputField>().text!="" && OptionInputField2.GetComponent<TMP_InputField>().text!=""){
          errorTxtOption.SetActive(false);
        }
       infoTxt.SetActive(false);
       buttonAddOption.SetActive(true);
       GameObject option= Instantiate(OptionField);
       option.transform.SetParent(OptionsContainer.transform,false);
       option.name="Option"+UnityEngine.Random.Range(50, 100);
       option.GetComponent<TMP_InputField>().onValueChanged.AddListener(delegate{OptionCharacterLimits(option.GetComponent<TMP_InputField>());});
    
      }
      else{
         buttonAddOption.SetActive(false);
        // buttonAddOption.GetComponent<Image>().color=Color.white;
        // buttonAddOption.SetActive(false);
        // buttonAddOption.GetComponent<Image>().sprite=disabledButtonSprite;
      }

    }
    public void QuestionCharacterLimits(){
       QuestionField.characterLimit=120;
       
    }
    public void OptionCharacterLimits(TMP_InputField option){
      option.GetComponent<TMP_InputField>().characterLimit=70;
    }
}
