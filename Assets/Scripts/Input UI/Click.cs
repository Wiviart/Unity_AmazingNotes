using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ParticleSystem squareEffect;
    [SerializeField] private ParticleSystem starEffect;
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
        if (score == 3) SpawnEffect(starEffect);
        Observer.OnClickTrigger(score);

        StartCoroutine(PlayAnimationAndDestroy());
    }

    private void SpawnEffect(ParticleSystem effect, Transform parent = null)
    {
        var pos = transform.position;
        pos.z = 10;
        var vfx = Instantiate(effect, pos, Quaternion.identity, parent);
        vfx.Play();
    }

    private IEnumerator PlayAnimationAndDestroy()
    {
        SpawnEffect(squareEffect, transform);

        var animHandler = new AnimatorHandler(anim);
        animHandler.PlayAnimation(DESTROY);
        yield return new WaitForSeconds(1);

        Destroy(transform.parent.gameObject);
    }
}