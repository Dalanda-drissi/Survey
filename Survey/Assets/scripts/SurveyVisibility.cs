using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class SurveyVisibility : MonoBehaviour
{
    [SerializeField]
    private GameObject clotureBtn;
    [SerializeField]
    private GameObject broadcastBtn;
    
    private string Label;
    void Start(){
      Label=this.gameObject.name;
       StartCoroutine(GetSurvey());
    }

    private IEnumerator GetSurvey(){
       UnityWebRequest Question = UnityWebRequest.Get("http://localhost:4000/Question/readByName/"+Label);
       yield return Question.SendWebRequest();
        if (Question.isNetworkError || Question.isHttpError)
        {    
            Debug.Log(Question.error);
            
        }
        else
        {
          var Questionresult = JsonUtility.FromJson<Question>(Question.downloadHandler.text);
          if (Questionresult.Visibility.Equals("true"))
          {
            clotureBtn.SetActive(true);
            broadcastBtn.SetActive(false);
          }
          else
          {
            clotureBtn.SetActive(false);
            broadcastBtn.SetActive(true);
          }
        }
    }
   private IEnumerator Visibility()
   {
    //    var Label=this.gameObject.name;
       UnityWebRequest Question = UnityWebRequest.Get("http://localhost:4000/Question/readByName/"+Label);
       yield return Question.SendWebRequest();
        if (Question.isNetworkError || Question.isHttpError)
        {    
            Debug.Log(Question.error);
            
        }
        else
        {
              var Questionresult = JsonUtility.FromJson<Question>(Question.downloadHandler.text);
            //   WWWForm form = new WWWForm();
            //   form.AddField("Visibility", "true");

            Question quest =new Question();
            quest.Visibility="true";
           var Json=JsonUtility.ToJson(quest);
              UnityWebRequest updateVisibility = UnityWebRequest.Put("http://localhost:4000/Question/update/Visibility/"+Questionresult._id,Json);
              updateVisibility.SetRequestHeader("Content-Type", "application/json");
              updateVisibility.SetRequestHeader("Accept", "application/json");
              yield return updateVisibility.SendWebRequest();
              if (updateVisibility.isNetworkError || updateVisibility.isHttpError)
                {    
                    Debug.Log(updateVisibility.error);
                    
                }
                else
                {
                     Debug.Log("Visibility updated" );
                }

        }

   }

private IEnumerator Invisible()
   {
    //    var Label=this.gameObject.name;
       UnityWebRequest Question = UnityWebRequest.Get("http://localhost:4000/Question/readByName/"+Label);
       yield return Question.SendWebRequest();
        if (Question.isNetworkError || Question.isHttpError)
        {    
            Debug.Log(Question.error);
            
        }
        else
        {
            var Questionresult = JsonUtility.FromJson<Question>(Question.downloadHandler.text);
           
            Question quest =new Question();
            quest.Visibility="false";
             var Json=JsonUtility.ToJson(quest);
              UnityWebRequest updateVisibility = UnityWebRequest.Put("http://localhost:4000/Question/update/Visibility/"+Questionresult._id,Json);
              updateVisibility.SetRequestHeader("Content-Type", "application/json");
              updateVisibility.SetRequestHeader("Accept", "application/json");
              yield return updateVisibility.SendWebRequest();
              if (updateVisibility.isNetworkError || updateVisibility.isHttpError)
                {    
                    Debug.Log(updateVisibility.error);
                    
                }
                else
                {
                     Debug.Log("Visibility updated" );
                }

        }

   }

 public void Cloture(){
       StartCoroutine(Invisible());
   }
   public void BroadCast(){
       StartCoroutine(Visibility());
   }
}
