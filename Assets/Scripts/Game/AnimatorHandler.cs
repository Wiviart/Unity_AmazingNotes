using UnityEngine;


public class AnimatorHandler
{
    private Animator _animator;

    public AnimatorHandler(Animator anim)
    {
        _animator = anim;
    }

    public void SetTrigger(string trigger)
    {
        _animator.SetTrigger(trigger);
    }

    public void SetBool(string name, bool value)
    {
        _animator.SetBool(name, value);
    }

    public void PlayAnimation(string clip)
    {
        _animator.Play(clip);
    }

    public bool IsPlaying(string clip)
    {
        return _animator.GetCurrentAnimatorStateInfo(0).IsName(clip) &&
               _animator.GetCurrentAnimatorStateInfo(0).normalizedTime < 1;
    }
}