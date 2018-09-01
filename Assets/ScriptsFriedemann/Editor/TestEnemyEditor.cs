using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(TestEnemy))]
public class TestEnemyEditor : Editor {

    TestEnemy script;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        script = (TestEnemy)target;
        if(GUILayout.Button(new GUIContent("Shoot")))
        {
            script.Shoot();
        }
    }

}
