using HairSystem.Data.Enums;

namespace HairSystem.Optimization.Dirty
{
    public sealed class DirtyManager
    {
        public DirtyCollection PhysicsDirty { get; }
        public DirtyCollection MeshDirty { get; }
        public DirtyCollection ColorDirty { get; }
        public DirtyCollection PatchDirty { get; }
        public DirtyCollection SaveDirty { get; }

        public DirtyManager()
        {
            PhysicsDirty = new DirtyCollection();
            MeshDirty = new DirtyCollection();
            ColorDirty = new DirtyCollection();
            PatchDirty = new DirtyCollection();
            SaveDirty = new DirtyCollection();
        }

        public void MarkDirty(int strandIndex, HairDirtyFlags flags)
        {
            if ((flags & HairDirtyFlags.Physics) != 0)
            {
                PhysicsDirty.Add(strandIndex);
            }
            
            if ((flags & HairDirtyFlags.Mesh) != 0)
            {
                MeshDirty.Add(strandIndex);
            }
            
            if ((flags & HairDirtyFlags.Color) != 0)
            {
                ColorDirty.Add(strandIndex);
            }
            
            if ((flags & HairDirtyFlags.Patch) != 0)
            {
                PatchDirty.Add(strandIndex);
            }
            
            if ((flags & HairDirtyFlags.Save) != 0)
            {
                SaveDirty.Add(strandIndex);
            }
        }
    }

}