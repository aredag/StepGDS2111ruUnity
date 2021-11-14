using UnityEngine;

public enum CharacterState
{
   Idle,
   Run,
   Walk
}
public class Character : MonoBehaviour
{
    public CharacterState characterState;
    public Texture2D portrait;
    public string nickname;
    public Color Color;
    public PlayerMovement playerMovement;
}

public class PlayerMovement{}
