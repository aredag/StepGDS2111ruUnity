using System;
using UnityEngine;

public enum RelicType
{
   Heartbreaker, 
   MaskedSpider,
   ScorpionTail,
   BladedPinchers
   
   
}
public class Relic : MonoBehaviour
{
    public RelicType relicType = RelicType.Heartbreaker;
   void OnDrawGizmos()
   {
       var name = "Relics\\" + relicType.ToString() + ".png";
       Gizmos.DrawIcon(transform.position, name, true);
   }
}
