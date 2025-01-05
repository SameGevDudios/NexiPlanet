using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 Movement => 
        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public bool UseBoost =>
        Input.GetKey(KeyCode.LeftShift);
    public float Zoom =>
        Input.GetAxis("Mouse ScrollWheel");
}
