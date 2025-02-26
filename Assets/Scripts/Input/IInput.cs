using UnityEngine;

public interface IInput
{
    Vector2 Movement();
    Vector3 MousePosition();
    bool UseBoost();
    bool Build();
    float Zoom();
}
