using System.Collections;
using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.EventSystems;

public class PointerEnter : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private ParticleSystem squareEffect;
    [SerializeField] private ParticleSystem starEffect;
    [SerializeField] private Animator anim;

    private bool isEntered = false;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (isEntered) return;
        isEntered = true;

        SpawnEffect(starEffect);
        SpawnEffect(squareEffect, transform);
        
        Observer.Instance.OnClickTrigger(3);

        StartCoroutine(PlayAnimationAndDestroy());
    }
    
    private void SpawnEffect(ParticleSystem effect, Transform parent = null)
    {
        Vector3 pos = transform.position;
        pos.z = 10;
        var particle = Instantiate(effect, pos, Quaternion.identity, parent);
        particle.Play();
    }

    private IEnumerator PlayAnimationAndDestroy()
    {
        var animHandler = new AnimatorHandler(anim);
        animHandler.PlayAnimation(ConstTag.DestroyClip);
        yield return new WaitForSeconds(1);

        Destroy(transform.parent.gameObject);
    }
}