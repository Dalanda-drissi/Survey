using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Networking;
using System.Collections.Generic;
public class SurveyManager : MonoBehaviour
{
    [SerializeField]
    private GameObject ExistTxt;
    [SerializeField]
    private GameObject Survey;
    [SerializeField]
    private GameObject Option;
    [SerializeField]
    private GameObject Container;
    private string id;
    private string nbUsers;
    public static List<Options> Options=new List<Options>();
    
    void Start()
    {
        id = UserInfo.id;
       
        StartCoroutine(GetAllUsers());
        StartCoroutine(GetQuestionList(id));

    }

        void Update()
    {
      

    }

    private IEnumerator GetAllUsers(){
       UnityWebRequest Users = UnityWebRequest.Get("http://localhost:4000/User/");
       yield return Users.SendWebRequest();
       nbUsers=Users.downloadHandler.text;
    }
    private IEnumerator GetQuestionList(string id){
    
     UnityWebRequest questionList = UnityWebRequest.Get("http://localhost:4000/Question/readByIdUser/"+id);
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
            
                GameObject SurveyGO= Instantiate(Survey);
                SurveyGO.name=QuestionList.Questions[i].Label;
                SurveyGO.transform.SetParent(Container.transform);
                GameObject Questiontxt = GameObject.Find(SurveyGO.name+"/QuestionMain/QuestionTxt");
                Questiontxt.GetComponent<Text>().text=QuestionList.Questions[i].QuestionTxt;
                GameObject OptionContainer = GameObject.Find(SurveyGO.name+"/Content/Scroll View/Viewport/Content");
                    foreach (var item in QuestionList.Questions[i].OptionsList)
                    {
                        GameObject OptionGO= Instantiate(Option);
                        Debug.Log(item.Label);
                        OptionGO.name=item.Label;
                        OptionGO.transform.SetParent(OptionContainer.transform);
                        GameObject Optiontxt = GameObject.Find(OptionGO.name+"/OptionTxt");
                        Optiontxt.GetComponent<Text>().text=item.OptionTxt;
                        float pourcentage=0;
                        if (int.Parse(item.NBVote)!=0){
                           
                            pourcentage = (float.Parse(item.NBVote, System.Globalization.CultureInfo.InvariantCulture) * 100 ) / float.Parse(nbUsers, System.Globalization.CultureInfo.InvariantCulture);
                        }
                        GameObject PecentageTxt = GameObject.Find(OptionGO.name+"/PecentageTxt");
                        PecentageTxt.GetComponent<Text>().text=pourcentage.ToString()+"%";
                        GameObject progressBar = GameObject.Find(OptionGO.name+"/progressBar");
                        progressBar.GetComponent<Slider>().value=pourcentage;
                        GameObject NBVoteTxt = GameObject.Find(OptionGO.name+"/NBVoteTxt");
                        NBVoteTxt.GetComponent<Text>().text=item.NBVote.ToString()+"Votes";

                    }
          

            }
            
         

        }
    }




   
}
