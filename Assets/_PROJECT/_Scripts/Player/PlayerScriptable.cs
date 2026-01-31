using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptable", menuName = "Scriptable Objects/PlayerScriptable")]
public class PlayerScriptable : ScriptableObject
{
    [Header("Movement")]
    public float walkSpeed = 5f;
    public float turnSpeed = 5f;
    [Header("Jump")]
    public float gravity = 9.81f;
    public float gravityMultiplier = 3.3f;
    public float jumpHeight = 2f;
    [Header("Jump Buffer")]
    public float jumpBufferTime = 0.22f;
}
