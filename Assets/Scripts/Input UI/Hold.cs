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