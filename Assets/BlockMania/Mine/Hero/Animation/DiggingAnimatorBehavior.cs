using System;
using UnityEngine;
namespace BlockMania.Mine.Hero.Animation
{
    public class DiggingAnimatorBehavior : StateMachineBehaviour
    {
        public event Action OnStateExitEvent;
        
        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            OnStateExitEvent?.Invoke();
        }
    }
}
