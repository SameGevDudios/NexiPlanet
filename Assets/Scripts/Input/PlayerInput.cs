using UnityEngine;

public static class PlayerInput
{
    public static Vector2 Movement => 
        new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    public static Vector3 MousePosition =>
        Input.mousePosition;
    public static bool UseBoost =>
        Input.GetKey(KeyCode.LeftShift);
    public static bool Build =>
        Input.GetMouseButtonDown(0);
    public static float Zoom =>
        Input.GetAxis("Mouse ScrollWheel");
}
