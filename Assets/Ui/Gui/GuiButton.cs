using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.EventSystems;
using UnityEngine.UI;

// TODO Refactor me layer
public class GuiButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Color hoverColor = new Color(0.523378f, 0.9433962f, 0.4405482f);

    Shadow shadow;
    RectTransform rect;
    Image buttonImage;

    bool pressed = false;

    Vector3 origonalPosition;
    Vector2 origonalShadowDistance;

    static Vector3 PressedOffset = new Vector3(0, 5, 0);

    private void Awake()
    {
        shadow = GetComponent<Shadow>();
        rect = GetComponent<RectTransform>();
        buttonImage = GetComponent<Image>();
    }

    private void Start()
    {
        origonalPosition = rect.localPosition;
        origonalShadowDistance = shadow.effectDistance;
    }

    private void Update()
    {
        if (pressed == true)
        {
            // rect.localPosition = Vector3.MoveTowards(rect.localPosition, origonalPosition - PressedOffset, 2f);
            // shadow.effectDistance = Vector2.MoveTowards(shadow.effectDistance, Vector2.zero, 2f);
        }
        else
        {
            // rect.localPosition = Vector3.MoveTowards(rect.localPosition, origonalPosition, 2f);
            // shadow.effectDistance = Vector2.MoveTowards(shadow.effectDistance, origonalShadowDistance, 2f);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        buttonImage.CrossFadeColor(hoverColor, .2f, false, false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        buttonImage.CrossFadeColor(new Color(1f, 1f, 1f), .3f, false, false);
    }
}
