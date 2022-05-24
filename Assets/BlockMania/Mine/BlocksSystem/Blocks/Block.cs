using System;
using UnityEngine;

namespace BlockMania.Mine.BlocksSystem.Blocks
{
    public class Block : MonoBehaviour
    {
        public event Action<Vector3> OnDestroyBlockEvent;

        public bool isDigable;
        [SerializeField] private Renderer render;
        [SerializeField] private Texture texture;
        [SerializeField] private float maxHealth = 5f;
        
        private static readonly int MainTexture = Shader.PropertyToID("_Main_Texture");
        private DestructionShader _destructionShader;
        private OutlineShader _outlineShader;
        private float _currentHealth;

        public void Initialize()
        {
            var materialPropertyBlock = new MaterialPropertyBlock();
            render.material.SetTexture(MainTexture, texture);
            _destructionShader = new DestructionShader(render, materialPropertyBlock, maxHealth);
            _outlineShader = new OutlineShader(render, materialPropertyBlock);
            _currentHealth = maxHealth;
        }

        public void ApplyDamage(float damage)
        {
            if (!isDigable) return;
            _currentHealth -= damage;
            _destructionShader.ChangeDestructionLayerRelativeHealth(_currentHealth);
            if (!(_currentHealth <= 0)) return;
            DestroyBlock();
        }

        public void ResetHealth()
        {
            _destructionShader.SetDestructionLayer(0);
            if (!(_currentHealth > 0f)) return;
            _currentHealth = maxHealth;
        }

        public void Select() => _outlineShader.EnableOutline();

        public void Deselect() => _outlineShader.DisableOutline();

        private void DestroyBlock()
        {
            var position = transform.position;
            OnDestroyBlockEvent?.Invoke(position);
            Destroy(gameObject);
        }
    }

}
