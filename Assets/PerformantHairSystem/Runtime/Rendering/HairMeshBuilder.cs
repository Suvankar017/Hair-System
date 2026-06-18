using UnityEngine;
using PerformantHairSystem.Core;

namespace PerformantHairSystem.Rendering
{
    public static class HairMeshBuilder
    {
        //public static HairMeshBuffers CreateBuffers(
        //    HairWorld world)
        //{
        //    int maxSegments =
        //        world.MaxStrands *
        //        (world.MaxParticlesPerStrand - 1);

        //    int maxVertices =
        //        maxSegments *
        //        HairShaderData.VERTICES_PER_SEGMENT;

        //    int maxIndices =
        //        maxSegments *
        //        HairShaderData.INDICES_PER_SEGMENT;

        //    return new HairMeshBuffers
        //    {
        //        Vertices =
        //            new Vector3[maxVertices],

        //        Colors =
        //            new Color32[maxVertices],

        //        UV =
        //            new Vector2[maxVertices],

        //        Triangles =
        //            new int[maxIndices]
        //    };
        //}

        public static HairMeshBuffers CreateBuffers(HairRenderLayout layout)
        {
            return new HairMeshBuffers()
            {
                Vertices = new Vector3[layout.TotalVertices],

                Colors = new Color32[layout.TotalVertices],

                UV = new Vector2[layout.TotalVertices],

                Triangles = new int[layout.TotalTriangles],

                VertexCount = layout.TotalVertices,

                TriangleCount = layout.TotalTriangles
            };
        }

        public static void Build(
            HairWorld world,
            HairRenderLayout layout,
            HairMeshBuffers buffers)
        {
            for (int strand = 0; strand < world.StrandCount; strand++)
            {
                BuildStrand(
                    world,
                    layout,
                    strand,
                    buffers);
            }

            buffers.VertexCount =
                layout.TotalVertices;

            buffers.TriangleCount =
                layout.TotalTriangles;
        }

        public static void BuildStrand(
            HairWorld world,
            HairRenderLayout layout,
            int strand,
            HairMeshBuffers buffers)
        {
            StrandRenderLayout strandLayout =
                layout.Strands[strand];

            int start =
                world.StrandStart[strand];

            int particleCount =
                world.StrandLength[strand];

            if (particleCount < 2)
                return;

            //----------------------------------
            // Remember where strand begins
            //----------------------------------

            //int vertexStart =
            //    buffers.VertexCount;
            int vertexStart =
                strandLayout.VertexStart;

            int triangleStart =
                strandLayout.TriangleStart;

            //----------------------------------
            // Total strand length
            //----------------------------------

            float totalLength = 0f;

            for (int i = 0;
                 i < particleCount - 1;
                 i++)
            {
                int a = start + i;
                int b = start + i + 1;

                totalLength +=
                    (world.Position[b]
                    - world.Position[a])
                    .magnitude;
            }

            float accumulatedLength = 0f;

            //----------------------------------
            // Vertices
            //----------------------------------

            for (int i = 0;
                 i < particleCount;
                 i++)
            {
                int particle =
                    start + i;

                Vector2 position =
                    world.Position[particle];

                Vector2 direction;

                //----------------------------------
                // Root
                //----------------------------------

                if (i == 0)
                {
                    Vector2 simulated =
                        (
                            world.Position[start + 1]
                            -
                            world.Position[start]
                        )
                        .normalized;

                    direction =
                        Vector2.Lerp(
                            world.RootDirection[strand],
                            simulated,
                            /*0.25f*/1.0f)
                        .normalized;
                }
                //----------------------------------
                // Tip
                //----------------------------------
                else if (i == particleCount - 1)
                {
                    direction =
                        (
                            world.Position[particle]
                            -
                            world.Position[particle - 1]
                        )
                        .normalized;
                }
                //----------------------------------
                // Middle
                //----------------------------------
                else
                {
                    direction =
                        (
                            world.Position[particle + 1]
                            -
                            world.Position[particle - 1]
                        )
                        .normalized;
                }

                Vector2 normal =
                    new Vector2(
                        -direction.y,
                        direction.x);

                float thickness =
                    world.Thickness[particle];

                Vector2 left =
                    position +
                    normal * thickness;

                Vector2 right =
                    position -
                    normal * thickness;

                int v = vertexStart + i * 2;

                //----------------------------------
                // Positions
                //----------------------------------

                buffers.Vertices[v] = left;

                buffers.Vertices[v + 1] = right;

                //----------------------------------
                // Colors
                //----------------------------------

                Color32 color = world.Color[particle];

                buffers.Colors[v] = color;

                buffers.Colors[v + 1] = color;

                //----------------------------------
                // UV
                //----------------------------------

                float uvY = (totalLength > 0.0f) ? (accumulatedLength / totalLength) : 0.0f;

                buffers.UV[v] = new Vector2(0.0f, uvY);

                buffers.UV[v + 1] = new Vector2(1.0f, uvY);

                //----------------------------------
                // Length accumulation
                //----------------------------------

                if (i < particleCount - 1)
                {
                    accumulatedLength +=
                        (
                            world.Position[particle + 1]
                            -
                            world.Position[particle]
                        )
                        .magnitude;
                }
            }

            //----------------------------------
            // Triangles
            //----------------------------------

            int triangleCursor =
                triangleStart;

            for (int i = 0;
                 i < particleCount - 1;
                 i++)
            {
                int root =
                    vertexStart +
                    i * 2;

                buffers.Triangles[
                    triangleCursor++] =
                    root;

                buffers.Triangles[
                    triangleCursor++] =
                    root + 2;

                buffers.Triangles[
                    triangleCursor++] =
                    root + 1;

                buffers.Triangles[
                    triangleCursor++] =
                    root + 1;

                buffers.Triangles[
                    triangleCursor++] =
                    root + 2;

                buffers.Triangles[
                    triangleCursor++] =
                    root + 3;

                //for (int i = 0; i < length - 1; i++)
                //{
                //    int a = start + i;
                //    int b = a + 1;

                //    Vector2 p0 = world.Position[a];
                //    Vector2 p1 = world.Position[b];

                //    Vector2 direction = (p1 - p0).normalized;

                //    Vector2 normal = new(-direction.y, direction.x);

                //    float width0 = world.Thickness[a];

                //    float width1 = world.Thickness[b];

                //    Vector2 left0 = p0 + normal * width0;

                //    Vector2 right0 = p0 - normal * width0;

                //    Vector2 left1 = p1 + normal * width1;

                //    Vector2 right1 = p1 - normal * width1;


                //    int v = buffers.VertexCount;
                //    int t = buffers.TriangleCount;

                //    buffers.Vertices[v + 0] = left0;
                //    buffers.Vertices[v + 1] = right0;

                //    buffers.Vertices[v + 2] = left1;
                //    buffers.Vertices[v + 3] = right1;


                //    Color32 c0 = world.Color[a];
                //    Color32 c1 = world.Color[b];

                //    buffers.Colors[v + 0] = c0;
                //    buffers.Colors[v + 1] = c0;

                //    buffers.Colors[v + 2] = c1;
                //    buffers.Colors[v + 3] = c1;


                //    buffers.UV[v + 0] = new Vector2(0, 0);

                //    buffers.UV[v + 1] = new Vector2(1, 0);

                //    buffers.UV[v + 2] = new Vector2(0, 1);

                //    buffers.UV[v + 3] = new Vector2(1, 1);

                //    buffers.Triangles[t + 0] = v + 0;
                //    buffers.Triangles[t + 1] = v + 2;
                //    buffers.Triangles[t + 2] = v + 1;

                //    buffers.Triangles[t + 3] = v + 1;
                //    buffers.Triangles[t + 4] = v + 2;
                //    buffers.Triangles[t + 5] = v + 3;

                //    buffers.VertexCount += 4;

                //    buffers.TriangleCount += 6;
                //}
            }
        }
    }
}