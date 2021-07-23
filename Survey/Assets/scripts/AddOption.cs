using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class AddOption : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private GameObject OptionField;
    [SerializeField]
    private GameObject OptionsContainer;
    public void OnPointerDown(PointerEventData eventData)
    {
       GameObject option= Instantiate(OptionField);
       option.transform.SetParent(OptionsContainer.transform);
       option.name="Option"+UnityEngine.Random.Range(50, 100);

    }
}
