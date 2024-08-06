using UnityEngine;

namespace LevelSelection
{
    [System.Serializable]
    public class LevelSelectionData
    {
        public RowData[] rows;
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
        public string jsonfilename;
        public string description;
        public string[] difficulties;
    }
}