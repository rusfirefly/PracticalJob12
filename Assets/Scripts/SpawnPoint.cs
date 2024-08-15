using UnityEngine;

public class SpawnPoint : Interactable
{
    [field: SerializeField] public Transform SpawnPosition { get; private set; }
    [SerializeField] private Animator _animator;

    private bool _isActiveSpawnPoint;
    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player plyer))
        {
            _player = plyer;
        }
    }

    public override void OnInteract()
    {
        if (_isActiveSpawnPoint == false)
        {
            Debug.Log("точка сохранения");
            _player.SetNewSpawPoint(SpawnPosition.position);
            _isActiveSpawnPoint = true;
            _animator.SetBool("isActive", true);
        }
    }
}
