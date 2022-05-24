using UnityEngine;
using Zenject;

namespace BlockMania.Mine.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private CameraRotatePanel cameraRotatePanel;
        [SerializeField] private DigButton digButton;

        public IJoystick Joystick => joystick; 
        public ICameraRotatePanel CameraRotatePanel => cameraRotatePanel; 
        public IDigButton DigButton => digButton; 
            
        [Inject]
        public void Initialize()
        {
            cameraRotatePanel.Initialize();
            digButton.Initialize();
            joystick.Initialize();
        }

        public void UpdatePass()
        {
            joystick.UpdatePass();
        }
    }

}