using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
public class AddSurvey : MonoBehaviour
{
    
    private  List<Options> Options = new List<Options>();

    public IEnumerator AddQuestion(){
        var idUser=UserInfo.id;
        var label="Survey"+UnityEngine.Random.Range(50, 100);
        Question quest =new Question();
        GameObject Question = GameObject.FindGameObjectWithTag("Question");
        string QuestionTxt =Question.GetComponent<InputField>().text.ToString();
        GameObject [] OptList = GameObject.FindGameObjectsWithTag("Option");
    if (OptList!=null){
        foreach(GameObject Opt in OptList)
        {
                Options Option = new Options();
                Option.OptionTxt = Opt.GetComponent<InputField>().text.ToString();
                Option.NBVote = "0";
                Option.Label=Opt.name;
                Options.Add(Option);
        }
    }
    else {
        Debug.Log("option null");
    }
        
        
        WWWForm form = new WWWForm();
        form.AddField("Label", label);
        form.AddField("QuestionTxt", QuestionTxt);
        form.AddField("Creator", idUser);
        form.AddField("Visibility", "false");
        
        UnityWebRequest www = UnityWebRequest.Post("http://localhost:4000/Question/create",form);
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {    
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Survey inserted correctly!" );
            var id =www.downloadHandler.text;
            string[] sArray = id.Split('"');
            id =sArray[1];
            quest.OptionsList=Options;
            var json = JsonUtility.ToJson(quest);
            UnityWebRequest putOptions = UnityWebRequest.Put("http://localhost:4000/Question/update/"+id,json);
            putOptions.SetRequestHeader("Content-Type", "application/json");
            putOptions.SetRequestHeader("Accept", "application/json");
            yield return putOptions.SendWebRequest();
        }
  
}

public void create(){
   StartCoroutine(AddQuestion());
 }
}
 



