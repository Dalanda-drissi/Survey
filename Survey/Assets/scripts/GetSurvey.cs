using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class GetSurvey : MonoBehaviour
{
    [SerializeField]
    private GameObject ExistTxt;
    [SerializeField]
    private GameObject Survey;
    [SerializeField]
    private GameObject Option;
    [SerializeField]
    private GameObject Container;
    public static List<Question> ListSurvey = new List<Question>();

    void Start()
    {
        StartCoroutine( GetQuestionList());
    }

  private IEnumerator GetQuestionList(){
    
     UnityWebRequest questionList = UnityWebRequest.Get("http://localhost:4000/Question/read");
     yield return questionList.SendWebRequest();
      if (questionList.isNetworkError || questionList.isHttpError)
        {    
            Debug.Log(questionList.error);
            
        }
        else
        {
            
            var QuestionList = JsonUtility.FromJson<ListQuestions>("{\"Questions\":" + questionList.downloadHandler.text + "}");
            
            if (questionList.downloadHandler.text=="[]"){
                ExistTxt.SetActive(true);
            }
            else{
               ExistTxt.SetActive(false);
             
               
            }
            for (int i = 0; i < QuestionList.Questions.Length; i++)
            {
                Question Quest = new Question();
                Quest._id=QuestionList.Questions[i]._id;
                Quest.Label=QuestionList.Questions[i].Label;
                Quest.OptionsList=QuestionList.Questions[i].OptionsList;
                Quest.QuestionTxt=QuestionList.Questions[i].QuestionTxt;
                ListSurvey.Add(Quest);
                GameObject SurveyGO= Instantiate(Survey);
                SurveyGO.name=QuestionList.Questions[i].Label;
                SurveyGO.transform.SetParent(Container.transform);
                GameObject Questiontxt = GameObject.Find(SurveyGO.name+"/QuestionMain/QuestionTxt");
                Questiontxt.GetComponent<Text>().text=QuestionList.Questions[i].QuestionTxt;
                GameObject OptionContainer = GameObject.Find(SurveyGO.name+"/Content/Scroll View/Viewport/Content");
                    foreach (var item in QuestionList.Questions[i].OptionsList)
                    {
                        GameObject OptionGO= Instantiate(Option);
                        OptionGO.name=item.Label;
                        OptionGO.transform.SetParent(OptionContainer.transform);
                        OptionGO.GetComponent<Toggle>().group=OptionContainer.GetComponent<ToggleGroup>();
                        GameObject Optiontxt = GameObject.Find(OptionGO.name+"/OptionTxt");
                        Optiontxt.GetComponent<Text>().text=item.OptionTxt;
                       

                    }
          

            }
            
         

        }
    }
}
