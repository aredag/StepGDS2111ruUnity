using UnityEditor;
using UnityEngine;

public class SelectAllOfTag : ScriptableWizard
{
    public string searchTag = "Set Tag";
    
    [MenuItem("Students Tools/Select all of Tag")]
    static void SelectAllOfTagWizard()
    {
        DisplayWizard<SelectAllOfTag>("Select All of Tag", "Select");
    }

    void OnWizardCreate()
    {
        var gameObjects = GameObject.FindGameObjectsWithTag(searchTag);
        Selection.objects = gameObjects;
    }
}
