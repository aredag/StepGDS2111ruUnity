using System;
using UnityEditor;
using UnityEngine;

public class CreateCharacterWizard : ScriptableWizard
{
    public Texture2D portrait;
    public Color color = Color.white;
    public string nickname = "Default";

    [MenuItem("Students Tools/Create Character")]
    static void CreateWizard()
    {
        DisplayWizard<CreateCharacterWizard>
            ("Create Character", "Create new character", "Update Selected Character");
    }

    void OnWizardCreate()
    {
        var character = new GameObject();

        var characterComponent = character.AddComponent<Character>();

        characterComponent.portrait = portrait;
        characterComponent.Color = color;
        characterComponent.nickname = nickname;
    }

    void OnWizardOtherButton()
    {
        if (Selection.activeTransform != null)
        {
            Character characterComponent = Selection.activeTransform.GetComponent<Character>();

            if (!characterComponent)
            {
                errorString = "No Character Component found";
                return;
            }
            
            errorString = "";
            
            characterComponent.portrait = portrait;
            characterComponent.Color = color;
            characterComponent.nickname = nickname;
        }
    }

    void OnWizardUpdate()
    {
        helpString = "Enter Character data";
    }
}
