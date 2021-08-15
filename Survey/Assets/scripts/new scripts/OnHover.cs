using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;  
using TMPro;
public class OnHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField]
    private GameObject Text;
    private Color color;
    void Start()
    {
    Color blue;
    ColorUtility.TryParseHtmlString("#193DC1", out blue);
   Text.GetComponent<TextMeshProUGUI>().color=blue;
       color= Text.GetComponent<TextMeshProUGUI>().color;
    }
     public void OnPointerEnter(PointerEventData eventData)
     {
         Text.GetComponent<TextMeshProUGUI>().color=Color.red;
    //  this.GetComponentInChildren<TextMesh>().color = Color.red; //Or however you do your color
     }

     public void OnPointerExit(PointerEventData eventData)
     {
         Text.GetComponent<TextMeshProUGUI>().color =color; //Or however you do your color
     }
}
