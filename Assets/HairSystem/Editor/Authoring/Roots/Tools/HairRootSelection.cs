using System.Collections.Generic;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootSelection
    {
        private readonly HashSet<int> _selectedIndices;

        public IReadOnlyCollection<int> SelectedIndices
        {
            get
            {
                return _selectedIndices;
            }
        }

        public bool HasSelection
        {
            get
            {
                return _selectedIndices.Count > 0;
            }
        }

        public HairRootSelection()
        {
            _selectedIndices =
                new HashSet<int>();
        }

        public void SelectSingle(
            int index)
        {
            _selectedIndices.Clear();

            _selectedIndices.Add(
                index);
        }

        public void Add(
            int index)
        {
            _selectedIndices.Add(
                index);
        }

        public bool Contains(
            int index)
        {
            return _selectedIndices.Contains(
                index);
        }

        public void Remove(
            int index)
        {
            _selectedIndices.Remove(
                index);
        }

        public void Clear()
        {
            _selectedIndices.Clear();
        }
    }
}