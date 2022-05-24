using UnityEngine;

namespace BlockMania.Mine.Hero
{
    [RequireComponent(typeof(Rigidbody))]
    public class HeroMovement : MonoBehaviour
    {
        [SerializeField] private float speed;
        private Rigidbody _rigidbody;
        private Transform _transform;
        
        public void Initialize()
        {
            _transform = GetComponent<Transform>();
            _rigidbody = GetComponent<Rigidbody>();
        }

        public void OnMovePlayer(float vertical, float horizontal)
        {
            _rigidbody.velocity = (_transform.forward *
                vertical + _transform.right *
                horizontal) * speed;
        }

    }
}
