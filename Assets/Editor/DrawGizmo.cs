using UnityEngine;
using UnityEditor;

public class DrawGizmo 
{
    [UnityEditor.DrawGizmo(GizmoType.Selected | GizmoType.Active)]
    static void DrawMyGizmo(Relic rlc, GizmoType type)
    {
       var name = "Relics\\" + rlc.relicType.ToString() + ".png";
       var position = rlc.transform.position;
       
       if(Vector3.Distance(position, Camera.current.transform.position) > 10f) 
           Gizmos.DrawIcon(position, name, true);
    }
}
