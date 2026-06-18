using UnityEngine;
using PerformantHairSystem.Authoring;

namespace PerformantHairSystem.Core
{
    public class HairWorldComponent : MonoBehaviour
    {
        [SerializeField]
        private HairRootContainer rootContainer;

        [SerializeField]
        private int maxParticlesPerStrand = 24;

        private HairWorld world;

        public HairWorld World => world;

        private void Awake()
        {
            world = HairWorldBaker.Build(
                rootContainer,
                maxParticlesPerStrand);
        }
    }
}