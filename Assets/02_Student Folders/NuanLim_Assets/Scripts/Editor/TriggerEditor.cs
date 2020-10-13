using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Trigger))]
public class TriggerEditor : Editor {
    public override void OnInspectorGUI() {
        base.OnInspectorGUI();
        Trigger t = (Trigger) target;

        t.isToggle = GUILayout.Toggle(t.isToggle, "Toggleable");

        if (t.isToggle) {
            t.resetDelay = EditorGUILayout.FloatField("Reset delay", t.resetDelay);
        }
    }
}
