﻿using System.Collections.Generic;
using WowPacketParser.Misc;
using WowPacketParser.SQL;

namespace WowPacketParser.Store.Objects
{
    [DBTableName("quest_poi")]
    public class QuestPOI
    {
        [DBFieldName("objIndex")]
        public int ObjectiveIndex;

        [DBFieldName("mapid")]
        public uint Map;

        [DBFieldName("WorldMapAreaId")]
        public uint WorldMapAreaId;

        [DBFieldName("FloorId")]
        public uint FloorId;

        [DBFieldName("unk3")]
        public uint UnkInt1;

        [DBFieldName("unk4")]
        public uint UnkInt2;

        [DBFieldName("VerifiedBuild")]
        public int VerifiedBuild = ClientVersion.BuildInt;

        public uint Idx;
        public ICollection<QuestPOIPoint> Points;
    }

    [DBTableName("quest_poi")]
    public class QuestPOIWoD
    {
        [DBFieldName("ObjectiveIndex")]
        public int ObjectiveIndex;

        [DBFieldName("QuestObjectiveID")]
        public int QuestObjectiveID;

        [DBFieldName("QuestObjectID")]
        public int QuestObjectID;

        [DBFieldName("MapID")]
        public uint MapID;

        [DBFieldName("WorldMapAreaId")]
        public uint WorldMapAreaId;

        [DBFieldName("Floor")]
        public uint Floor;
        [DBFieldName("Priority")]
        public int Priority;

        [DBFieldName("Flags")]
        public int Flags;

        [DBFieldName("WorldEffectID")]
        public int WorldEffectID;

        [DBFieldName("PlayerConditionID")]
        public int PlayerConditionID;

        [DBFieldName("WoDUnk1")]
        public int WoDUnk1;

        [DBFieldName("VerifiedBuild")]
        public int VerifiedBuild = ClientVersion.BuildInt;

        public uint Idx;
        public ICollection<QuestPOIPoint> Points;
    }
}
