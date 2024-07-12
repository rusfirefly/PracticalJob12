using DG.Tweening;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private SpawnPoint _spawnPoint;
    [SerializeField] private float _dieZone;

    private Interactable _interactable;


    private void OnValidate()
    {
        _rigidbody??=GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(_interactable)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _interactable.OnInteract();
            }
        }

        if(transform.position.y < _dieZone)
        {
            Die();
        }
    }

    public void Die()
    {
        Respawn();
        StopPlayer();
    }

    public void Move(Vector3 move)
    {
        _rigidbody.AddForce(move, _forceMode);
    }

    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.GetComponent<Interactable>();

        if(_interactable)
        {
            _interactable.ShowMessage();
        }

        Coin coin = other.gameObject.GetComponent<Coin>();
        if (coin)
        {
            SaveHandler.instance.savesData.NewCoin();
            SaveHandler.instance.Save();
            coin.Collect();
        }

        if (other.gameObject.tag == "Enemy")
        {
            Die();
        }

        SpawnPoint spawnPoint = other.gameObject.GetComponent<SpawnPoint>();
        if (spawnPoint)
        {
            SetNewSpawPoint(spawnPoint);
        }
    }

    private void SetNewSpawPoint(SpawnPoint spawnPoint)
    {
        if (_spawnPoint != spawnPoint)
        {
            _spawnPoint = spawnPoint;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactable)
        {
            _interactable.HideMessage();
        }

        _interactable = null;
    }

    private void Respawn() => transform.position = _spawnPoint.spawnPosition.position;

    private void StopPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
