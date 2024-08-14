using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace LevelSelection
{
    [System.Serializable]
    public class LevelSelectionData
    {
        public RowData[] rows;

        public static LevelSelectionData Parse(TextAsset jsonData)
        {
            LevelSelectionData levelSelectionData = JsonUtility.FromJson<LevelSelectionData>(jsonData.text);
            return levelSelectionData;
        }
    }

    [System.Serializable]
    public class RowData
    {
        public string title;
        public LevelData[] levels;
    }

    [System.Serializable]
    public class LevelData
    {
        public string label;
        public string levelId;
        public string jsonfilename;
        public string description;
        public string[] difficulties;

        public string getClearInfo()
        {
            return ClearData.GetClearDataFromKey(levelId).getSimpleInfo();
        }
    }
}