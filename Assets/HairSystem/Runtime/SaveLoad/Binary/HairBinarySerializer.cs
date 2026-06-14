using HairSystem.Data.Enums;
using HairSystem.SaveLoad.Contracts;
using HairSystem.SaveLoad.Data;
using System;
using System.IO;
using UnityEngine;

namespace HairSystem.SaveLoad.Binary
{
    public sealed class HairBinarySerializer : IHairSerializer
    {
        private const string Magic = "HSAV";

        public byte[] Serialize<T>(T value)
        {
            if (value is not HairCharacterSaveData saveData)
            {
                throw new NotSupportedException(
                    $"Type {typeof(T)} is not supported.");
            }

            using MemoryStream stream = new();

            using BinaryWriter writer = new(stream);

            WriteHeader(writer);

            WriteCharacter(writer, saveData);

            return stream.ToArray();
        }

        public T Deserialize<T>(byte[] data)
        {
            if (typeof(T) != typeof(HairCharacterSaveData))
            {
                throw new NotSupportedException(
                    $"Type {typeof(T)} is not supported.");
            }

            using MemoryStream stream = new(data);

            using BinaryReader reader = new(stream);

            ValidateHeader(reader);

            HairCharacterSaveData saveData = ReadCharacter(reader);

            return (T)(object)saveData;
        }

        private static void WriteHeader(BinaryWriter writer)
        {
            writer.Write(Magic);

            writer.Write(HairSaveVersion.Current);
        }

        private static void ValidateHeader(BinaryReader reader)
        {
            string magic = reader.ReadString();

            if (magic != Magic)
            {
                throw new InvalidDataException(
                    "Invalid hair save file.");
            }

            int version = reader.ReadInt32();

            if (version > HairSaveVersion.Current)
            {
                throw new InvalidDataException(
                    $"Unsupported save version {version}");
            }
        }

        private static void WriteCharacter(
            BinaryWriter writer,
            HairCharacterSaveData saveData)
        {
            writer.Write(saveData.Regions.Length);

            for (int i = 0; i < saveData.Regions.Length; i++)
            {
                WriteRegion(writer, saveData.Regions[i]);
            }
        }

        private static HairCharacterSaveData ReadCharacter(BinaryReader reader)
        {
            HairCharacterSaveData saveData = new()
            {
                Version = HairSaveVersion.Current
            };

            int regionCount = reader.ReadInt32();

            saveData.Regions = new HairRegionSaveData[regionCount];

            for (int i = 0; i < regionCount; i++)
            {
                saveData.Regions[i] = ReadRegion(reader);
            }

            return saveData;
        }

        private static void WriteColor32(BinaryWriter writer, Color32 color)
        {
            writer.Write(color.r);

            writer.Write(color.g);

            writer.Write(color.b);

            writer.Write(color.a);
        }

        private static Color32 ReadColor32(BinaryReader reader)
        {
            return new Color32(
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte(),
                reader.ReadByte());
        }

        private static void WriteVector2(BinaryWriter writer, Vector2 value)
        {
            writer.Write(value.x);

            writer.Write(value.y);
        }

        private static Vector2 ReadVector2(BinaryReader reader)
        {
            return new Vector2(
                reader.ReadSingle(),
                reader.ReadSingle());
        }

        private static void WritePatch(BinaryWriter writer, HairPatchSaveData patch)
        {
            writer.Write(patch.Width);

            writer.Write(patch.Height);

            writer.Write(patch.Pixels.Length);

            for (int i = 0; i < patch.Pixels.Length; i++)
            {
                WriteColor32(writer, patch.Pixels[i]);
            }
        }

        private static HairPatchSaveData ReadPatch(BinaryReader reader)
        {
            HairPatchSaveData patch = new()
            {
                Width = reader.ReadInt32(),
                Height = reader.ReadInt32()
            };

            int pixelCount = reader.ReadInt32();

            patch.Pixels = new Color32[pixelCount];

            for (int i = 0; i < pixelCount; i++)
            {
                patch.Pixels[i] = ReadColor32(reader);
            }

            return patch;
        }

        private static void WritePoint(BinaryWriter writer, HairPointSaveData point)
        {
            WriteVector2(writer, point.RestPosition);

            writer.Write(point.Width);

            WriteColor32(writer, point.Color);
        }

        private static HairPointSaveData ReadPoint(BinaryReader reader)
        {
            HairPointSaveData point = new()
            {
                RestPosition = ReadVector2(reader),
                Width = reader.ReadSingle(),
                Color = ReadColor32(reader)
            };

            return point;
        }

        private static void WriteStrand(BinaryWriter writer, HairStrandSaveData strand)
        {
            writer.Write(strand.StrandId);

            writer.Write(strand.RootIndex);

            writer.Write(strand.CurrentLength);

            writer.Write((int)strand.StyleType);

            writer.Write(strand.Points.Length);

            for (int i = 0; i < strand.Points.Length; i++)
            {
                WritePoint(writer, strand.Points[i]);
            }
        }

        private static HairStrandSaveData ReadStrand(BinaryReader reader)
        {
            HairStrandSaveData strand = new()
            {
                StrandId = reader.ReadInt32(),
                RootIndex = reader.ReadInt32(),
                CurrentLength = reader.ReadSingle(),
                StyleType = (HairStyleType)reader.ReadInt32()
            };

            int pointCount = reader.ReadInt32();

            strand.Points = new HairPointSaveData[pointCount];

            for (int i = 0; i < pointCount; i++)
            {
                strand.Points[i] = ReadPoint(reader);
            }

            return strand;
        }

        private static void WriteRegion(BinaryWriter writer, HairRegionSaveData region)
        {
            writer.Write((int)region.RegionType);

            WritePatch(writer, region.Patch);

            writer.Write(region.Strands.Length);

            for (int i = 0; i < region.Strands.Length; i++)
            {
                WriteStrand(writer, region.Strands[i]);
            }
        }

        private static HairRegionSaveData ReadRegion(BinaryReader reader)
        {
            HairRegionSaveData region = new()
            {
                RegionType = (HairRegionType)reader.ReadInt32(),
                Patch = ReadPatch(reader)
            };

            int strandCount = reader.ReadInt32();

            region.Strands = new HairStrandSaveData[strandCount];

            for (int i = 0; i < strandCount; i++)
            {
                region.Strands[i] = ReadStrand(reader);
            }

            return region;
        }
    }
}