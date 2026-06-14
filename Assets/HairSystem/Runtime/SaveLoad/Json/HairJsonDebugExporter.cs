using UnityEngine;
using HairSystem.SaveLoad.Contracts;

namespace HairSystem.SaveLoad.Json
{
    public sealed class HairJsonDebugExporter : IHairDebugExporter
    {
        public string Export<T>(T value)
        {
            return JsonUtility.ToJson(value, true);
        }
    }
}