using UnityEngine;
using UnityEngine.EventSystems;

public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    bool isHold = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Hold");
        isHold = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Release");
        isHold = false;
    }
}