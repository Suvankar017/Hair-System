using UnityEngine;
using PerformantHairSystem.Core;

namespace PerformantHairSystem.Rendering
{
    [RequireComponent(typeof(MeshFilter))]
    [RequireComponent(typeof(MeshRenderer))]
    public class HairRenderer : MonoBehaviour
    {
        [SerializeField]
        private HairWorldComponent worldComponent;

        [SerializeField]
        private int maxStrandsPerFrame = 32;

        private HairMeshBuffers buffers;
        private HairRenderLayout layout;

        private Mesh mesh;

        private readonly HairRenderState renderState = new();

        private readonly DirtyStrandTracker dirtyTracker = new();

        private uint[] renderedVersions;

        private void Awake()
        {
            mesh = new Mesh();

            mesh.MarkDynamic();

            GetComponent<MeshFilter>()
                .sharedMesh = mesh;
        }

        private void Start()
        {
            HairWorld world = worldComponent.World;

            renderedVersions = new uint[world.StrandCount];

            layout = HairRenderLayoutBuilder.Build(world);

            buffers = HairMeshBuilder.CreateBuffers(layout);

            HairMeshBuilder.Build(world, layout, buffers);

            UploadMesh();

            for (int strand = 0; strand < world.StrandCount; strand++)
            {
                renderedVersions[strand] = world.StrandVersion[strand];
            }
        }

        private void LateUpdate()
        {
            HairWorld world = worldComponent.World;

            CollectDirtyStrands(world);

            bool meshChanged = ProcessDirtyStrands(world);

            if (!meshChanged)
            {
                //UnityEngine.Debug.Log("No Mesh Upload Required");
                return;
            }

            //UnityEngine.Debug.Log("Uploading Mesh ...");

            UploadMesh();
        }

        private void CollectDirtyStrands(HairWorld world)
        {
            for (int strand = 0; strand < world.StrandCount; strand++)
            {
                if (renderedVersions[strand] == world.StrandVersion[strand])
                {
                    continue;
                }

                dirtyTracker.Enqueue(strand);

                renderedVersions[strand] = world.StrandVersion[strand];
            }
        }

        private bool ProcessDirtyStrands(HairWorld world)
        {
            bool changed = false;

            int budget = maxStrandsPerFrame;

            while (budget > 0 && dirtyTracker.TryDequeue(out int strand))
            {
                RebuildStrand(world, strand);

                changed = true;

                budget--;
            }

            return changed;
        }

        private void UploadMesh()
        {
            mesh.Clear(false);

            mesh.SetVertices(
                buffers.Vertices,
                0,
                buffers.VertexCount);

            mesh.SetColors(
                buffers.Colors,
                0,
                buffers.VertexCount);

            mesh.SetUVs(
                0,
                buffers.UV,
                0,
                buffers.VertexCount);

            mesh.SetTriangles(
                buffers.Triangles,
                0,
                buffers.TriangleCount,
                0);

            mesh.RecalculateBounds();
        }

        private void RebuildStrand(HairWorld world, int strand)
        {
            HairMeshBuilder.BuildStrand(
                world,
                layout,
                strand,
                buffers);
        }
    }
}