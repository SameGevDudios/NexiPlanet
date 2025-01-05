using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    [SerializeField] private float _speed, _boost;
    [SerializeField] private Limit _limitX, _limitY;

    private void Update()
    {
        MovePlayer();
        LimitPosition();
    }
    private void MovePlayer()
    {
        float boost = _playerInput.UseBoost ? _boost : 1;
        transform.position +=
            (Vector3.forward * _playerInput.Movement.y +
            Vector3.right * _playerInput.Movement.x) * _speed * boost;
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
