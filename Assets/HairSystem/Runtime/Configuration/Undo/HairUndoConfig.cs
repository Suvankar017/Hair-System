using UnityEngine;

namespace HairSystem.Configuration.Undo
{
    [CreateAssetMenu(
        fileName = "HairUndoConfig",
        menuName = "Hair System/Undo Config")]
    public sealed class HairUndoConfig : ScriptableObject
    {
        [SerializeField]
        [Min(1)]
        private int _maximumHistoryCount = 100;

        public int MaximumHistoryCount
        {
            get
            {
                return _maximumHistoryCount;
            }
        }
    }
}