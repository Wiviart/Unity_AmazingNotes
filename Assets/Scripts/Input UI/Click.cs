using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        int score = 0;
        
        switch (transform.position.y)
        {
            case > -4.25f and <= -3.75f:
                print("Perfect");
                score = 3;
                break;
            case > -3.75f and <= -3.25f:
                print("Great");
                score = 2;
                break;
            default:
                print("Good");
                score = 1;
                break;
        }

        Observer.OnClickTrigger(score);
        
        Destroy(transform.parent.gameObject);
    }
}