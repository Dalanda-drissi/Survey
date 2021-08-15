using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class ShowHideMenu : MonoBehaviour, IPointerDownHandler
{
    private bool buttonPressed ;
    // [SerializeField]
    // private GameObject Content;
    [SerializeField]
    private GameObject deleteButtonContainer;
    [SerializeField]
    private GameObject editDeleteButtonsContainer;
    [SerializeField]
    private GameObject responseContainer;
  public void OnPointerDown(PointerEventData eventData)
    {
        if(buttonPressed)
        {
            buttonPressed = false;
            deleteButtonContainer.SetActive(false);
            editDeleteButtonsContainer.SetActive(false);
            // Content.SetActive(false);
        }
        else 
        {
            buttonPressed = true;
            if (responseContainer.transform.childCount!=0){
             deleteButtonContainer.SetActive(true);
            }
            else{
             editDeleteButtonsContainer.SetActive(true);
            }
            // Content.SetActive(true);
        }
    }
}
