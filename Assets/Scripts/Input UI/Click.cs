using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ParticleSystem effect;
    [SerializeField] private Animator anim;
    private const string DESTROY = "Destroy";
    [SerializeField] private Note note;
    bool isClicked = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isClicked) return;
        isClicked = true;
        
        note.Stop();

        int score = ScoreChecker.ScoreByPosition(transform);
        Observer.OnClickTrigger(score);

        StartCoroutine(PlayAnimationAndDestroy());
    }

    private IEnumerator PlayAnimationAndDestroy()
    {
        var pos = transform.position;
        pos.z = 10;
        var effectInstance = Instantiate(
            effect, pos, Quaternion.identity, transform);
        effectInstance.Play();

        var animHandler = new AnimatorHandler(anim);
        animHandler.PlayAnimation(DESTROY);
        yield return new WaitForSeconds(1);

        Destroy(transform.parent.gameObject);
    }
}