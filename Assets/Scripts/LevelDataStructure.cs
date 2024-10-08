using UnityEngine;

namespace Level
{

    [System.Serializable]
    public class LevelData
    {
        public LevelInfo level;
        public Goal[] goal;
        public Section[] sections;

        public static LevelData Parse(TextAsset jsonData)
        {
            LevelData levelData = JsonUtility.FromJson<LevelData>(jsonData.text);
            return levelData;
        }
    }

    [System.Serializable]
    public class LevelInfo
    {
        public string levelId;
        public string levelName;
        public string difficulty;
        public string description;
        public int initialHealth;
        public int initialShield;
    }

    [System.Serializable]
    public class Goal
    {
        public string type;
    }

    [System.Serializable]
    public class Section
    {
        public bool ground;
        public ObjectData[] objects;
    }

    [System.Serializable]
    public class ObjectData
    {
        public string type;
        public float x;
        public float y;
    }
}