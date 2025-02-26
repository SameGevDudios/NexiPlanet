using UnityEngine;

public class PlayerInput  : IInput
{
    public Vector2 Movement() => 
        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public Vector3 MousePosition() =>
        Input.mousePosition;
    public bool UseBoost() =>
        Input.GetKey(KeyCode.LeftShift);
    public bool Build() =>
        Input.GetMouseButtonDown(0);
    public float Zoom() =>
        Input.GetAxis("Mouse ScrollWheel");
}
