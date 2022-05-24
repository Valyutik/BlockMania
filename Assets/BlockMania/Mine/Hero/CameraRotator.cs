using UnityEngine;

namespace BlockMania.Mine.Hero
{
    public class CameraRotator : MonoBehaviour
    {
        private const float Threshold = 0.01f;

        [SerializeField] private float sensitivity = 5f;
        [SerializeField] private float bottomClamp = -70f, topClamp = 70f;
        [SerializeField] private Transform heroTransform;
        private Transform _cameraTr;
        private float _cameraAngleRotation;
        private float _heroAngleRotation;

        public void Initialize()
        {
            _cameraTr = GetComponent<Transform>();
        }

        public void OnRotateCamera(Vector3 delta)
        {
            if (!(delta.sqrMagnitude >= Threshold))
                return;
            _cameraAngleRotation += delta.y * sensitivity * Time.deltaTime;
            _heroAngleRotation = delta.x * sensitivity * Time.deltaTime;

            _cameraAngleRotation = ClampAngle(_cameraAngleRotation, bottomClamp, topClamp);
            
            _cameraTr.localRotation = Quaternion.Euler(_cameraAngleRotation, 0f, 0f);
            
            heroTransform.Rotate(Vector3.up * _heroAngleRotation);
        }
    
        private static float ClampAngle(float lfAngle, float lfMin, float lfMax)
        {
            if (lfAngle < -360f) lfAngle += 360f;
            if (lfAngle > 360f) lfAngle -= 360f;
            return Mathf.Clamp(lfAngle, lfMin, lfMax);
        }
    }
}
