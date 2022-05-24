using UnityEngine;

namespace BlockMania.Mine.BlocksSystem.Blocks
{
    public class OutlineShader
    {
        private readonly Renderer _renderer;
        private readonly MaterialPropertyBlock _materialPropertyBlock;
        private static readonly int IsOutlined = Shader.PropertyToID("_IsOutlined");

        public OutlineShader(Renderer renderer, MaterialPropertyBlock materialPropertyBlock)
        {
            _renderer = renderer;
            _materialPropertyBlock = materialPropertyBlock;
            SetOutline(0);
        }

        public void EnableOutline() => SetOutline(1);
        public void DisableOutline() => SetOutline(0);
        
        private void SetOutline(float value)
        {
            _materialPropertyBlock.SetFloat(IsOutlined, value);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }
    }
}