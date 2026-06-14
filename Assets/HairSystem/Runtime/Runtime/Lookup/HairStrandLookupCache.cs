using System.Collections.Generic;
using HairSystem.Data.Characters;
using HairSystem.Data.Enums;
using HairSystem.Data.Regions;
using HairSystem.Data.Strands;

namespace HairSystem.Runtime.Lookup
{
    public sealed class HairStrandLookupCache
    {
        private readonly Dictionary<int, HairStrandData> _strandLookup;

        public HairStrandLookupCache()
        {
            _strandLookup = new Dictionary<int, HairStrandData>();
        }

        public void Rebuild(HairCharacterData character)
        {
            _strandLookup.Clear();

            foreach (KeyValuePair<HairRegionType, HairRegionData> pair in character.Regions)
            {
                HairRegionData region = pair.Value;

                int count = region.Strands.Count;

                for (int i = 0; i < count; i++)
                {
                    HairStrandData strand = region.Strands[i];

                    _strandLookup[strand.StrandId] = strand;
                }
            }
        }

        public bool TryGetStrand(int strandId, out HairStrandData strand)
        {
            return _strandLookup.TryGetValue(strandId, out strand);
        }

        public HairStrandData GetStrand(int strandId)
        {
            return _strandLookup[strandId];
        }

        public bool Contains(int strandId)
        {
            return _strandLookup.ContainsKey(strandId);
        }

        public void Clear()
        {
            _strandLookup.Clear();
        }
    }
}