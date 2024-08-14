using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable]
public class ClearData
{
    [System.Serializable]
    public class ClearEntry
    {
        public string difficulty;
        public int health = -1;
        public List<string> additionalInfo;
        public ClearEntry(string difficulty, int hearts)
        {
            this.difficulty = difficulty;
            this.health = hearts;
        }
        public string getSimpleInfo()
        {
            string status = health == -1 ? "NoPlay" : health == 0 ? "Failed" : "Cleared";
            return $"{difficulty}: {status}";
        }
    }
    public string key;
    public List<ClearEntry> clearEntries = new List<ClearEntry>();
    public string getSimpleInfo()
    {
        return !clearEntries.Any() ? "" : (clearEntries.Aggregate("", (acc, x) => acc + x.getSimpleInfo() + ". ") + "\n");
    }
    public override string ToString()
    {
        return JsonUtility.ToJson(this);
    }
    public ClearData(string key)
    {
        this.key = key;
        this.clearEntries = new List<ClearEntry>();
    }
    public void saveClearData()
    {
        PlayerPrefs.SetString(key, ToString());
    }
    public static void UpdateClearEntry(string key, ClearEntry clearEntry)
    {
        ClearData temp = GetClearDataFromKey(key);
        bool flag = false;
        foreach (var entry in temp.clearEntries)
        {
            if (entry.difficulty == clearEntry.difficulty)
            {
                flag = true;
                if (clearEntry.health > entry.health)
                {
                    entry.health = clearEntry.health;
                    entry.additionalInfo = clearEntry.additionalInfo;
                }
                break;
            }
        }
        if (!flag)
        {
            temp.clearEntries.Add(clearEntry);
        }
        Debug.Log("UpdateClearEntry: " + JsonUtility.ToJson(new List<ClearEntry> { clearEntry }));
        Debug.Log("UpdateClearEntry: " + temp.ToString());
        PlayerPrefs.SetString(key, temp.ToString());
    }
    public static ClearData GetClearDataFromKey(string key)
    {
        if (PlayerPrefs.HasKey(key))
        {
            Debug.Log(PlayerPrefs.GetString(key));
            var temp = JsonUtility.FromJson<ClearData>(PlayerPrefs.GetString(key));
            if (temp.clearEntries == null) { temp.clearEntries = new List<ClearEntry>(); }
            return temp;
        }
        else
        {
            return new ClearData(key);
        }
    }
}