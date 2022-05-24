using UnityEngine;

namespace BlockMania.Mine.BlocksSystem.Blocks
{
    public class DestructionShader
    {
        private const float CountDestructionLayers = 10f;
        private static readonly int DestructionLayer = Shader.PropertyToID("_Destruction_Layer");
        private readonly float _maxHealth;
        private readonly Renderer _renderer;
        private readonly MaterialPropertyBlock _materialPropertyBlock;

        public DestructionShader(Renderer renderer, MaterialPropertyBlock materialPropertyBlock, float maxHealth)
        {
            _materialPropertyBlock = materialPropertyBlock;
            _maxHealth = maxHealth;
            _renderer = renderer;
            SetDestructionLayer(0);
        }
        
        public void ChangeDestructionLayerRelativeHealth(float currentHealth)
        {
            var currentLayer = CountDestructionLayers - (currentHealth * CountDestructionLayers) / _maxHealth;
            SetDestructionLayer(Mathf.Round(currentLayer));
        }
        
        public void SetDestructionLayer(float value)
        {
            _materialPropertyBlock.SetFloat(DestructionLayer, value);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}