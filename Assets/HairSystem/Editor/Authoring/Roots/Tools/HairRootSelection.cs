using System.Collections.Generic;

namespace HairSystem.EditorTools.Authoring.Roots.Tools
{
    public sealed class HairRootSelection
    {
        private readonly HashSet<int> _selectedIndices;

        private int _primarySelection;

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

        public int Count
        {
            get
            {
                return _selectedIndices.Count;
            }
        }

        public int PrimarySelection
        {
            get
            {
                return _primarySelection;
            }
        }

        public HairRootSelection()
        {
            _selectedIndices =
                new HashSet<int>();

            _primarySelection =
                -1;
        }

        public void SelectSingle(
            int index)
        {
            _selectedIndices.Clear();

            _selectedIndices.Add(
                index);

            _primarySelection =
                index;
        }

        public void Add(
            int index)
        {
            _selectedIndices.Add(
                index);

            if (_primarySelection < 0)
            {
                _primarySelection =
                    index;
            }
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

            if (_primarySelection == index)
            {
                _primarySelection =
                    -1;
            }
        }

        public void Clear()
        {
            _selectedIndices.Clear();

            _primarySelection =
                -1;
        }
    }
}