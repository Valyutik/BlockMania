using System;
using UnityEngine;
using UnityEngine.VFX;

namespace BlockMania.Mine.BlocksSystem
{
    public interface IDigger
    {
        event Action OnDigEvent;
        void OnStopDigPreviousBlock();
    }
    public class BlockDigger : MonoBehaviour, IDigger
    {
        public event Action OnDigEvent;
        
        [SerializeField] private float diggingDistance = 5f;
        [SerializeField] private string layerMask;
        [SerializeField] private VisualEffect destructionParticleSystem;
        
        private Camera _camera;
        private Vector2 _centerScreen;
        private RaycastHit _previousRaycastHit;
        private LayerMask _layerMask;
        private Blocks.Block _currentBlock;

        public void Initialize(Camera mainCamera)
        {
            _layerMask = LayerMask.GetMask(layerMask);
            _camera = mainCamera;
            _centerScreen = new Vector2(Screen.width / 2f, Screen.height / 2f);
            destructionParticleSystem.Stop();
        }

        public void UpdatePass()
        {
            GetBlock();
        }

        public void OnStopDigPreviousBlock()
        {
            if (_currentBlock != null)
                _currentBlock.ResetHealth();
        }
        
        // Used in the "Dig" animation clip
        public void OnDigBlock()
        {
            if(!_currentBlock)
                return;
            PlayDestructionEffect();
            _currentBlock.ApplyDamage(1f);
            OnDigEvent?.Invoke();
        }

        private void GetBlock()
        {
            var ray = _camera.ScreenPointToRay(_centerScreen);
            if (Physics.Raycast(ray, out var hit, diggingDistance, _layerMask))
            {
                if (hit.collider == _previousRaycastHit.collider)
                    return;
                if (_currentBlock != null)
                    _currentBlock.Deselect();
                OnStopDigPreviousBlock();
                _previousRaycastHit = hit;
                _currentBlock = _previousRaycastHit.collider.GetComponent<Blocks.Block>();
                _currentBlock.Select();
            }
            else
                OnStopDigPreviousBlock();
        }

        private void PlayDestructionEffect()
        {
            destructionParticleSystem.transform.position = _currentBlock.transform.position;
            destructionParticleSystem.Play();
        }
    }
}
