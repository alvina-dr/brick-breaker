using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ButtonAnimation : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private HorizontalLayoutGroup layoutGroup;
    public void OnPointerEnter(PointerEventData eventData)
    {
        layoutGroup.padding.top += 3; 
        layoutGroup.padding.bottom -= 3;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        layoutGroup.padding.top -= 3;
        layoutGroup.padding.bottom += 3;
    }
}
