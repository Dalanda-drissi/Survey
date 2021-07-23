using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Authentification : MonoBehaviour, IPointerDownHandler
{
     public void OnPointerDown(PointerEventData eventData)
    {
      StartCoroutine(GetUser());
    }

    private IEnumerator GetUser(){
     GameObject EmailInputField = GameObject.FindGameObjectWithTag("Email"); 
     GameObject PasswordInputField = GameObject.FindGameObjectWithTag("Password");   
     string Email =EmailInputField.GetComponent<TMPro.TMP_InputField>().text.ToString();
     string Password =PasswordInputField.GetComponent<TMPro.TMP_InputField>().text.ToString();
     UnityWebRequest user = UnityWebRequest.Get("http://localhost:4000/User/read/"+Email);
     yield return user.SendWebRequest();
      if (user.isNetworkError || user.isHttpError)
        {    
            Debug.Log(user.error);
            Debug.Log("invalid Email ");
        }
        else
        {
            var result = JsonUtility.FromJson<User>(user.downloadHandler.text);
          
            if (Password.Equals(result.Password)  ){
                UserInfo.id=result._id;
                if (result.Role.Equals("Organisateur")){
                 SceneManager.LoadScene(1);
                }
                else{
                SceneManager.LoadScene(2);
                }
               

            }
            else{
                Debug.Log("invalid password ");
            }
        }
    }
}
