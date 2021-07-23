using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class deleteOption : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject OptionField;

    // Update is called once per frame
     public void OnPointerDown(PointerEventData eventData)
    {
        Destroy(OptionField);
    }
}
