using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class JoyButton : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    public bool pressed;

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void SetUnPressed()
    {
        pressed = false;
    }
}
