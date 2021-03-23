using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IDDispenser : MonoBehaviour {
    private static int _uniqueID;
    private static Dictionary<int, GameObject> IDMap;

    private static PopulationManager pm;

    void Start() {
        pm = GameObject.Find("PopulationManager").GetComponent<PopulationManager>();
        _uniqueID = 0;
        IDMap = new Dictionary<int, GameObject>();
    }

    public static bool ContainsID(int ID) {
        return IDMap.ContainsKey(ID);
    }

    public static GameObject GetGameObjectWithID(int ID) {
        if (IDMap.ContainsKey(ID)) {
            return IDMap[ID];
        } else {
            return null;
        }
    }

    public static int RegisterObject(GameObject go) {
        _uniqueID += 1;
        pm.RegisterObject(go);
        IDMap.Add(_uniqueID, go);
        return _uniqueID;
    }

    public static void UnregisterObject(int ID) {
        pm.UnregisterObject(IDMap[ID]);
        IDMap.Remove(ID);
    }
}