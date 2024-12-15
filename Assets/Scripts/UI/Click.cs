using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class Click : MonoBehaviour, IPointerDownHandler
{
    [SerializeField] private ParticleSystem squareEffect;
    [SerializeField] private ParticleSystem starEffect;
    [SerializeField] private Animator anim;
    [SerializeField] private Note note;

    private bool isClicked = false;

    public void OnPointerDown(PointerEventData eventData)
    {
        if (isClicked) return;
        isClicked = true;

        note.Stop();

        int score = ScoreChecker.ScoreByPosition(transform);
        if (score == 3) SpawnEffect(starEffect);
        Observer.OnClickTrigger(score);

        SpawnEffect(squareEffect, transform);
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
        var animHandler = new AnimatorHandler(anim);
        animHandler.PlayAnimation(ConstTag.DestroyClip);
        yield return new WaitForSeconds(1);

        Destroy(transform.parent.gameObject);
    }
}