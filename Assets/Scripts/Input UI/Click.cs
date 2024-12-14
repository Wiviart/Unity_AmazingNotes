using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        int score = ScoreChecker.ScoreByPosition(transform);

        Observer.OnClickTrigger(score);

        Destroy(transform.parent.gameObject);
    }
}