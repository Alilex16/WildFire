using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ChooseLevel : MonoBehaviour, IPointerClickHandler
{
    [Header("Active Modifiers (Max = 3)")]
    public GameObject ActiveModifier01;
    public GameObject ActiveModifier02;
    public GameObject ActiveModifier03;
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if (ActiveModifier01 != null)
        {
            ActiveModifier01.SetActive(true);
        }
        if (ActiveModifier02 != null)
        {
            ActiveModifier02.SetActive(true);
        }
        if (ActiveModifier03 != null)
        {
            ActiveModifier03.SetActive(true);
        }
    }
}