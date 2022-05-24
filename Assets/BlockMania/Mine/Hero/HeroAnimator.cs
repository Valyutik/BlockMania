using BlockMania.Mine.Hero.Animation;
using UnityEngine;

namespace BlockMania.Mine.Hero
{
    [RequireComponent(typeof(Animator))]
    public class HeroAnimator : MonoBehaviour
    {
        private Animator animator;
        private static readonly int WalkHash = Animator.StringToHash("Walk");
        private static readonly int StartDigHash = Animator.StringToHash("StartDig");
        private static readonly int EndDigHash = Animator.StringToHash("EndDig");

        public DiggingAnimatorBehavior diggingAnimatorBehavior { get; private set; }

        public void Initialize()
        {
            animator = GetComponent<Animator>();
            diggingAnimatorBehavior = animator.GetBehaviour<DiggingAnimatorBehavior>();
        }
        
        public void Walk() => animator.SetBool(WalkHash, true);
        public void Idle() => animator.SetBool(WalkHash, false);
        public void StartDig() => animator.SetTrigger(StartDigHash);
        public void EndDig() => animator.SetTrigger(EndDigHash);
    }
}
