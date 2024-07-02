using UnityEngine;

public class CameraMovement : MonoBehaviour, IMovable
{
    [SerializeField] private Transform _playerTransform;

    private Camera _camera;
    private Vector3 _offset;

    private void Start()
    {
        _camera = Camera.main;
        SetOffsetPosition();
    }

    
    private void FixedUpdate()
    {
        Move(_offset);
    }

    public void Move(Vector3 move)
    {
        _camera.transform.position = _playerTransform.position + _offset;
    }

    private void SetOffsetPosition()
    {
        _offset = _camera.transform.position - _playerTransform.position;
    }
}
