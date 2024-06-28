using UnityEngine;

public class CameraMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Transform _playerTransform;
    private Vector3 _offset;

    private void Start()
    {
        SetOffsetPosition();
    }

    private void FixedUpdate()
    {
        Move(_offset);
    }

    public void Move(Vector3 move)
    {
        transform.position = _playerTransform.position + _offset;
    }

    private void SetOffsetPosition()
    {
        _offset = transform.position - _playerTransform.position;
    }
}
