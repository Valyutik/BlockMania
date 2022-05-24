using BlockMania.Mine.BlocksSystem;
using BlockMania.Mine.Hero.Picks;
using BlockMania.Mine.UI;
using UnityEngine;
using Zenject;

namespace BlockMania.Mine.Hero
{
    public class HeroSystem : MonoBehaviour
    {
        [SerializeField] private CameraRotator cameraRotator;
        [SerializeField] private HeroAnimator heroAnimator;
        [SerializeField] private HeroMovement heroMovement;
        [SerializeField] private PicksSystem picksSystem;

        [Inject]
        public void Initialize(UISystem uiSystem, BlockSystem blockSystem)
        {
            cameraRotator.Initialize();
            uiSystem.CameraRotatePanel.OnDragEvent += cameraRotator.OnRotateCamera;
            
            heroMovement.Initialize();
            uiSystem.Joystick.OnDragEvent += heroMovement.OnMovePlayer;
            
            picksSystem.Initialize();
            blockSystem.Digger.OnDigEvent += picksSystem.HitSounds.PlayHitSound;
            
            heroAnimator.Initialize();
            heroAnimator.diggingAnimatorBehavior.OnStateExitEvent += blockSystem.Digger.OnStopDigPreviousBlock;
            uiSystem.Joystick.OnBeginDragEvent += heroAnimator.Walk;
            uiSystem.Joystick.OnEndDragEvent += heroAnimator.Idle;
            uiSystem.DigButton.OnStartHoldEvent += heroAnimator.StartDig;
            uiSystem.DigButton.OnEndHoldEvent += heroAnimator.EndDig;
        }
    }
}