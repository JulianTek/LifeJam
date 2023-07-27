using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using EventSystem;

[CustomEditor(typeof(PlayerExperienceHandler))]
public class PlayerExperienceEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if (GUILayout.Button("Level up!"))
            EventChannels.PlayerEvents.OnPlayerLevelUp?.Invoke(2);
    }
}
