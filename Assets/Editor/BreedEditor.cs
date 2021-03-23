using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BreedEditorSupport))]
public class BreedEditor : Editor
{
    Breed br;
    public Dictionary<int, Breed> breedCollection;
    int displaying = 0;

    void OnEnable() {
        // get all the json file under path ./Assets/Resources/Breed/
        Reload();

        br = ((BreedEditorSupport) target).breed;
    }

    private void Reload() {
        breedCollection = new Dictionary<int, Breed>();
        string jsonString = "{}";
        foreach (string path in Directory.GetFiles("./Assets/Resources/Breed")) {
            if (Path.GetExtension(path) == ".json") {
                jsonString = File.ReadAllText(path);
                br = JsonUtility.FromJson<Breed>(jsonString);
                breedCollection[br.breedID] = br;
            }
        }
    }

    public override void OnInspectorGUI()
    {
        int[] ids = breedCollection.Keys.ToArray();
        string[] displayNames = ids.Select(x=>x.ToString()).ToArray();

        displaying = EditorGUILayout.IntPopup("Now displaying breed with ID: ", (int) displaying, displayNames, ids);
        if (breedCollection.Count > 0) {
            if (breedCollection.ContainsKey(displaying)) {
                ((BreedEditorSupport) target).displayPleaseDoNotChangeAnythingHere = breedCollection[displaying];
                base.OnInspectorGUI();
                br = ((BreedEditorSupport) target).breed;
            }
        }

        if (GUILayout.Button("Save")) //10
        {
            Debug.Log(br.breedName + " (" + br.breedID +") added into collection");
            string jsonString = JsonUtility.ToJson(br);
            File.WriteAllText("./Assets/Resources/Breed/" + br.breedID + ".json", jsonString);
            breedCollection[br.breedID] = JsonUtility.FromJson<Breed>(jsonString);
        }

        if (GUILayout.Button("Reload")) //8
        {
            Reload();
        }

        if (GUILayout.Button("Delete")) //8
        {
            Debug.Log("Plz manually delete ./Assets/Resources/Breed/" + br.breedID + ".json");
        }
    }
}