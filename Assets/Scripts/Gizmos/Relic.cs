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
}
