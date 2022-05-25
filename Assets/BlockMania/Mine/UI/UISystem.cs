using UnityEngine;
using Zenject;

namespace BlockMania.Mine.UI
{
    public class UISystem : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private CameraRotatePanel cameraRotatePanel;
        [SerializeField] private DigButton digButton;
        [SerializeField] private SceneСhangeTestButtonUp sceneСhangeTestButtonUp;
        [SerializeField] private SceneСhangeTestButtonDown sceneСhangeTestButtonDown;

        public IJoystick Joystick => joystick; 
        public ICameraRotatePanel CameraRotatePanel => cameraRotatePanel; 
        public IDigButton DigButton => digButton;
        public SceneСhangeTestButtonUp SceneСhangeTestButtonUp => sceneСhangeTestButtonUp;
        public SceneСhangeTestButtonDown SceneСhangeTestButtonDown => sceneСhangeTestButtonDown;
            
        [Inject]
        public void Initialize()
        {
            cameraRotatePanel.Initialize();
            digButton.Initialize();
            joystick.Initialize();
            sceneСhangeTestButtonUp.Initialize();
            sceneСhangeTestButtonDown.Initialize();
        }

        public void UpdatePass()
        {
            joystick.UpdatePass();
        }
    }

}