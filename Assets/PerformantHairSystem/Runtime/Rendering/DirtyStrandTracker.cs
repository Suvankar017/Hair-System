using System.Collections.Generic;

namespace PerformantHairSystem.Rendering
{
    public sealed class DirtyStrandTracker
    {
        private readonly Queue<int>
            queue =
                new();

        private readonly HashSet<int>
            queued =
                new();

        public int Count =>
            queue.Count;

        public void Enqueue(
            int strand)
        {
            if (queued.Add(strand))
            {
                queue.Enqueue(strand);
            }
        }

        public bool TryDequeue(
            out int strand)
        {
            if (queue.Count == 0)
            {
                strand = -1;
                return false;
            }

            strand =
                queue.Dequeue();

            queued.Remove(
                strand);

            return true;
        }
    }
}