using UnityEditor;
using UnityEngine;


public class DrawState 
{
    
    [UnityEditor.DrawGizmo(GizmoType.Selected | GizmoType.Active)]
    static void DrawMyGizmo(Character ch, GizmoType type)
    {
       var name = "CharactersState\\" + ch.characterState.ToString() + ".png";
       var position = ch.transform.position;
       
       Gizmos.DrawIcon(position, name, true);
    }
}
