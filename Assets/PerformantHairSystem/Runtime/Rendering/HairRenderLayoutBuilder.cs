using PerformantHairSystem.Core;

namespace PerformantHairSystem.Rendering
{
    public static class HairRenderLayoutBuilder
    {
        public static HairRenderLayout Build(
            HairWorld world)
        {
            HairRenderLayout layout = new()
            {
                Strands = new StrandRenderLayout[world.StrandCount]
            };

            int vertexCursor = 0;

            int triangleCursor = 0;

            for (int strand = 0;
                 strand < world.StrandCount;
                 strand++)
            {
                int particleCount =
                    world.StrandLength[strand];

                int vertexCount =
                    particleCount * 2;

                int triangleCount =
                    (particleCount - 1) * 6;

                layout.Strands[strand] =
                    new StrandRenderLayout
                    {
                        VertexStart =
                            vertexCursor,

                        VertexCount =
                            vertexCount,

                        TriangleStart =
                            triangleCursor,

                        TriangleCount =
                            triangleCount
                    };

                vertexCursor +=
                    vertexCount;

                triangleCursor +=
                    triangleCount;
            }

            layout.TotalVertices =
                vertexCursor;

            layout.TotalTriangles =
                triangleCursor;

            return layout;
        }
    }
}