using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
/*
[CustomEditor(typeof(Map))]
public class MapEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Map map = (Map)target;

        if (map.stages == null)
        {
            map.stages = new List<StageBase>();
        }

        for (int i = 0; i < map.stages.Count; i++)
        {
            EditorGUILayout.BeginHorizontal();
            map.stages[i].mapObj = (GameObject)EditorGUILayout.ObjectField("Map Object", map.stages[i].mapObj, typeof(GameObject), true);
            map.stages[i].sceneName = EditorGUILayout.TextField("Scene Name", map.stages[i].sceneName);
            EditorGUILayout.EndHorizontal();
        }

        if (GUILayout.Button("Add Stage"))
        {
            map.stages.Add(new StageBase(null, ""));
        }
        if(GUILayout.Button("Remove Stage"))
        {
            map.stages.RemoveAt(map.stages.Count - 1);
        }
        if (GUI.changed)
        {
            EditorUtility.SetDirty(target);
        }
    }
}
*/