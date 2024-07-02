using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    private float _vertical;
    private float _horizontal;
    private Vector3 _move;
    private Camera _camera;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _camera = Camera.main;
    }

    private void Update()
    {
        _vertical = Input.GetAxis("Vertical") * _speed;
        _horizontal = Input.GetAxis("Horizontal") * _speed;
    }

    private void FixedUpdate()
    {
        _move = new Vector3(_horizontal, 0, _vertical);
        _player.LookInDirection(_camera.transform.forward);
        _player.Move(_move);
    }
}
