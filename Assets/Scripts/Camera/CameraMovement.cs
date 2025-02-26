using UnityEngine;
using Zenject;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _speed, _boost;
    [SerializeField] private Limit _limitX, _limitY;
    [Inject] private IInput _input;

    private void Update()
    {
        MovePlayer();
        LimitPosition();
    }
    private void MovePlayer()
    {
        float boost = _input.UseBoost() ? _boost : 1;
        transform.position +=
            (Vector3.forward * _input.Movement().y +
            Vector3.right * _input.Movement().x) * _speed * boost;
    }
    private void LimitPosition()
    {
        transform.position = new Vector3(
          Mathf.Clamp(transform.position.x, _limitX.Min, _limitX.Max),
          transform.position.y,
          Mathf.Clamp(transform.position.z, _limitY.Min, _limitY.Max)
          );
    }
}
