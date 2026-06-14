using UnityEngine;
using HairSystem.Configuration.Generation;
using HairSystem.Configuration.Physics;
using HairSystem.Configuration.Rendering;
using HairSystem.Configuration.Patches;
using HairSystem.Configuration.Styling;
using HairSystem.Configuration.Undo;
using HairSystem.Configuration.Tools;

namespace HairSystem.Configuration
{
    [CreateAssetMenu(
        fileName = "HairSystemConfiguration",
        menuName = "Hair System/System Configuration")]
    public sealed class HairSystemConfiguration : ScriptableObject
    {
        [SerializeField]
        private HairGenerationConfig _generation;

        [SerializeField]
        private HairPhysicsConfig _physics;

        [SerializeField]
        private HairRenderingConfig _rendering;

        [SerializeField]
        private HairPatchConfig _patches;

        [SerializeField]
        private HairStyleConfig _styling;

        [SerializeField]
        private HairToolsConfig _tools;

        [SerializeField]
        private HairUndoConfig _undo;

        public HairGenerationConfig Generation
        {
            get
            {
                return _generation;
            }
        }

        public HairPhysicsConfig Physics
        {
            get
            {
                return _physics;
            }
        }

        public HairRenderingConfig Rendering
        {
            get
            {
                return _rendering;
            }
        }

        public HairPatchConfig Patches
        {
            get
            {
                return _patches;
            }
        }

        public HairStyleConfig Styling
        {
            get
            {
                return _styling;
            }
        }

        public HairToolsConfig Tools
        {
            get
            {
                return _tools;
            }
        }

        public HairUndoConfig Undo
        {
            get
            {
                return _undo;
            }
        }
    }
}