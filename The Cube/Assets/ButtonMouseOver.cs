using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class UIButtonSoundEvent : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler
{

    public void OnPointerEnter(PointerEventData ped)
    {
        SoundManager.PlaySound(SoundManager.Sound.UiRollver);
    }

    public void OnPointerDown(PointerEventData ped)
    {
        SoundManager.PlaySound(SoundManager.Sound.UiRollver);
    }
}