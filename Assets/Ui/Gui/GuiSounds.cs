using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

// TODO Refactor this to use an AudioManager
public class GuiSounds : MonoBehaviour, IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler
{
    AudioSource uiHoverSound;
    AudioSource uiClickSound;
    AudioSource uiUnClickSound;

    private void Awake()
    {
        var sounds = GetComponentsInParent<AudioSource>();
        uiHoverSound = sounds[0];
        uiClickSound = sounds[1];
        uiUnClickSound = sounds[2];
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        uiHoverSound.Play();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        uiClickSound.Play();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        uiUnClickSound.Play();
    }
}
