using UnityEngine;
using UnityEditor;

public class DrawRadius 
{
    [UnityEditor.DrawGizmo(GizmoType.Selected | GizmoType.NonSelected)]
    static void DrawMyGizmo(Relic rlc, GizmoType type)
    {
       var position = rlc.transform.position;
       
        Gizmos.DrawWireSphere(position, rlc.damageRadius);
    }
}
