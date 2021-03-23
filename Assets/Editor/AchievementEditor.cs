using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AchievementEditorSupport))]
public class AchievementEditor : Editor
{
    Achievement achi;
    public Dictionary<int, Achievement> achievementCollection;
    int displaying = 0;

    void OnEnable() {
        // get all the json file under path ./Assets/Resources/Achievement/
        Reload();

        achi = ((AchievementEditorSupport) target).achievement;
    }

    private void Reload() {
        achievementCollection = new Dictionary<int, Achievement>();
        string jsonString = "{}";
        foreach (string path in Directory.GetFiles("./Assets/Resources/Achievement")) {
            if (Path.GetExtension(path) == ".json") {
                jsonString = File.ReadAllText(path);
                achi = JsonUtility.FromJson<Achievement>(jsonString);
                achievementCollection[achi.id] = achi;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        int[] ids = achievementCollection.Keys.ToArray();
        string[] displayNames = ids.Select(x=>x.ToString()).ToArray();

        displaying = EditorGUILayout.IntPopup("Now displaying achievement with ID: ", (int) displaying, displayNames, ids);
        if (achievementCollection.Count > 0) {
            if (achievementCollection.ContainsKey(displaying)) {
                ((AchievementEditorSupport) target).displayPleaseDoNotChangeAnythingHere = achievementCollection[displaying];
                base.OnInspectorGUI();
                achi = ((AchievementEditorSupport) target).achievement;
            }
        }

        if (GUILayout.Button("Save")) //10
        {
            Debug.Log(achi.name + " (" + achi.id +") added into collection");
            string jsonString = JsonUtility.ToJson(achi);
            File.WriteAllText("./Assets/Resources/Achievement/" + achi.id + ".json", jsonString);
            achievementCollection[achi.id] = JsonUtility.FromJson<Achievement>(jsonString);
        }

        if (GUILayout.Button("Reload")) //8
        {
            Reload();
        }

        if (GUILayout.Button("Delete")) //8
        {
            Debug.Log("Plz manually delete ./Assets/Resources/Achievement/" + achi.id + ".json");
        }
    }
}
