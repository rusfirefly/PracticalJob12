using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private Player _player;
    [SerializeField] private bool _debugDrawForce;
    private float _vertical;
    private float _horizontal;
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
        Vector3 force = CalculeForce(_vertical, _horizontal);

        if (_debugDrawForce)
        {
            Debug.DrawRay(_player.transform.position, force, Color.red, 300f);
        }

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
}
