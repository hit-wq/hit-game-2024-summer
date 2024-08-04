using System;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class LevelInitializer : MonoBehaviour
{
    public TextAsset levelJsonData;
    public GameObject sectionObject;
    public GameObject groundObject;
    public List<string> strlist;
    public List<GameObject> objectlist;

    private Dictionary<string, GameObject> objectdict = new Dictionary<string, GameObject>();

    private void Awake()
    {
        LevelData levelData = ParseLevel(levelJsonData);

        if (strlist.Count != objectlist.Count)
        {
            throw new Exception("Level Initializer: element count not matching!");
        }

        for (int i = 0; i < strlist.Count; i++)
        {
            objectdict.Add(strlist[i], objectlist[i]);
        }

        int count = 0;
        foreach (Section section in levelData.sections)
        {
            var currentSection = Instantiate(sectionObject, new Vector2(count * 100, 0), Quaternion.identity);
            count += 1;
            // Instantiate the ground object
            if (section.ground)
            {
                Instantiate(groundObject, currentSection.transform, false).transform
                    .SetLocalPositionAndRotation(new Vector2(40, -4.5f), Quaternion.identity);
            }
            // Instantiate all objects
            foreach (ObjectData objectData in section.objects)
            {
                GameObject theObject = objectdict[objectData.type];
                if (theObject)
                {
                    Instantiate(theObject, currentSection.transform).transform
                        .SetLocalPositionAndRotation(new Vector2(objectData.x, objectData.y), Quaternion.identity);
                }
            }
        }
    }

    private void Update()
    {

    }

    public LevelData ParseLevel(TextAsset jsonData)
    {
        LevelData levelData = JsonUtility.FromJson<LevelData>(jsonData.text);
        return levelData;
    }
}