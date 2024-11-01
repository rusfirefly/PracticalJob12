using System;
using UnityEngine;

public class PlayerInput : MonoBehaviour, IPaused
{
    public static event Action Paused;
    [SerializeField] private float _speed;
    [SerializeField] private IMovable _player;
    [SerializeField] private bool _debugDrawForce;
    [SerializeField] private bool _isEnable;
  
    private float _vertical;
    private float _horizontal;
    private Camera _camera;

    public bool IsPaused { get; set; }

    private void Awake()
    {
        _player = GetComponent<Player>();
        _camera = Camera.main;
    }

    private void Update()
    {   
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Paused?.Invoke();
        }

        if (IsPaused) return;

        if (_isEnable == false) return;

        _vertical = Input.GetAxis("Vertical") * _speed;
        _horizontal = Input.GetAxis("Horizontal") * _speed;
    }

    public void Enable() => _isEnable = true;

    public void Disable() => _isEnable = false;

    private void FixedUpdate()
    {
        if (IsPaused)  return;

        if (_isEnable == false) return;

        Vector3 force = CalculeForce(_vertical, _horizontal);
        _player.Move(force);
    }

    private Vector3 CalculeForce(float movementX, float movementY)
    {
        Vector3 forward = _camera.transform.forward;
        Vector3 right = _camera.transform.right;

        forward.Normalize();
        right.Normalize();

        forward.y = 0;
        right.y = 0;

        return movementX * forward + movementY * right;
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
