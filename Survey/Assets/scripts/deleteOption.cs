using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class deleteOption : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject OptionField;

     public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(OptionField);
    }
}
