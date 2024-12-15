using UnityEngine;

namespace AmazingNotes.Game
{
    public class AnimatorHandler
    {
        private readonly Animator _animator;

        public AnimatorHandler(Animator anim)
        {
            _animator = anim;
        }

        public void PlayAnimation(string clip)
        {
            _animator.Play(clip);
        }
    }
}