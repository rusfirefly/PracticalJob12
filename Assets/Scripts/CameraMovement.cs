using UnityEngine;

public class CameraMovement : MonoBehaviour, IMovable, IPaused
{
    [SerializeField] private Transform _playerTransform;

    private Camera _camera;
    private Vector3 _offset;

    public bool IsPaused { get; set; }

    private void Start()
    {
        _camera = Camera.main;
        SetOffsetPosition();
    }

    
    private void FixedUpdate()
    {
        if(IsPaused) return;

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

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
    }
}
