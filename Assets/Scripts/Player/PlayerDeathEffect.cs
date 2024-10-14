using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerDeathEffect 
{
    private Rigidbody _rigidbody;
    private PlayerInput _playerInput;
    private Animator _animator;
    private int _dieTimeMillisecond = 1200;
    private Vector3 _positionSpawn;
    private Transform _transform;

    public PlayerDeathEffect(PlayerInput playerInput, Animator animator, Rigidbody rigidbody)
    {
        _rigidbody = rigidbody;
        _playerInput = playerInput;
        _animator = animator;
    }

    public async void Die(Transform transform, Vector3 positionSpawn)
    {
        _transform = transform;
        _positionSpawn = positionSpawn;

        _playerInput.Disable();
        StopPlayer();
        await StartDeathEffect();
        StopPlayer();
        Respawn();
        await ShowPlayer();
        _playerInput.Enable();

    }

    private async Task StartDeathEffect()
    {
        _animator.SetBool("isDeath", true);
        await Task.Delay(_dieTimeMillisecond);
    }

    private async Task ShowPlayer()
    {
        _animator.SetBool("isDeath", false);
        await Task.Delay(_dieTimeMillisecond);
    }

    private void Respawn()
    {
        _transform.position = _positionSpawn;
    }

    private void StopPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
