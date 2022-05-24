using UnityEngine;

namespace BlockMania.Mine.Hero.Picks
{
    public class PicksSystem : MonoBehaviour
    {
        [SerializeField] private HitSounds hitSounds;
        public HitSounds HitSounds => hitSounds;

        public void Initialize()
        {
            hitSounds.Initialize();
        }
    }
}