using UnityEngine;
using PerformantHairSystem.Core;
using PerformantHairSystem.Data;

namespace PerformantHairSystem.Debug
{
    public class HairDebugRenderer : MonoBehaviour
    {
        [SerializeField]
        private HairWorldComponent worldComponent;

        private HairWorld world;
        private Camera mainCamera;

        private void Start()
        {
            world = worldComponent.World;
            mainCamera = Camera.main;
        }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying)
                return;

            if (worldComponent == null)
                return;

            if (worldComponent.World == null)
                return;

            Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            const float interactionRadius = 0.3f;
            const float interactionRadiusSqr = interactionRadius * interactionRadius;

            UnityEditor.Handles.color = Color.cyan;
            UnityEditor.Handles.DrawWireDisc(mousePosition, Vector3.forward, interactionRadius);

            for (int strand = 0; strand < world.StrandCount; strand++)
            {
                Color color = Color.green;

                if ((world.Flags[strand] & StrandFlags.Sleeping) != 0)
                {
                    color = Color.yellow;
                }

                int start = world.StrandStart[strand];

                int length = world.StrandLength[strand];

                Gizmos.color = color;

                for (int i = 0; i < length - 1; i++)
                {
                    int p = start + i;

                    Vector2 current = world.Position[p];
                    Vector2 next = world.Position[p + 1];

                    Gizmos.DrawLine(current, next);
                }

                for (int i = 0; i < length; i++)
                {
                    int p = start + i;

                    Vector2 current = world.Position[p];

                    float distance = (current - mousePosition).sqrMagnitude;
                    if (distance < interactionRadiusSqr)
                    {
                        Gizmos.color = new Color(1.0f, 0.0f, 0.0f, 0.4f);
                        Gizmos.DrawSphere(current, 0.03f);
                    }
                }
            }
        }
    }
}
