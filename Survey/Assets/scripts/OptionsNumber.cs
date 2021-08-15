using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class OptionsNumber : MonoBehaviour, IPointerDownHandler
{
    private GameObject[] optionsNb;
    [SerializeField]
    private GameObject LimitTxt;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        optionsNb=GameObject.FindGameObjectsWithTag("optionsContent");
        if (optionsNb.Length>=5)
        {
           LimitTxt.SetActive(true);
           this.GetComponent<AddOption>().enabled=false;
        }
        else
        {
            LimitTxt.SetActive(false);
           this.GetComponent<AddOption>().enabled=true;
        }
    }

  
}
