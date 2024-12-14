using UnityEngine;
using UnityEngine.EventSystems;

public class Hold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Transform pointer;
    [SerializeField] private Transform endPoint;
    private Vector3 pointerPosition;
    private bool isHold = false;
    private bool AtEndPoint => pointer.position.y >= endPoint.position.y;

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
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        print("Release");
        DestroyAndAddScore();
    }

    private void DestroyAndAddScore()
    {
        isHold = false;
        var score = AtEndPoint ? 3 : 2;
        Observer.OnClickTrigger(score);
        Destroy(transform.parent.gameObject);
    }

    private void MovePointer()
    {
        pointer.position = pointerPosition;
    }
}