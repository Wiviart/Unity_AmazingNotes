using UnityEngine;
using UnityEngine.EventSystems;

public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform endPoint;
    private Vector3 pointerPosition;
    private bool isHold = false;
    private bool AtEndPoint => pointer.position.y >= endPoint.position.y;
    int score = 0;

    private void Update()
    {
        if (!isHold) return;
        MovePointer();

        if (AtEndPoint) DestroyAndAddScore();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        print("Hold");
        isHold = true;
        pointerPosition = pointer.position;

        score = ScoreChecker.ScoreByPosition(transform);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Release");
        DestroyAndAddScore();
    }

    private void DestroyAndAddScore()
    {
        isHold = false;
        var multiplier = AtEndPoint ? 2 : 1;
        Observer.OnClickTrigger(score * multiplier);
        Destroy(transform.parent.gameObject);
    }

    private void MovePointer()
    {
        pointer.position = pointerPosition;
    }
}