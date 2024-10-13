using System.Threading.Tasks;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SkillShowInvisibleObjects))]

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _dieZone;

  
    private IDeathEffect _deathEffect;
    private Rigidbody _rigidbody;
    private Vector3 _spawnPoint;
    private Interactable _interactable;
    private SkillShowInvisibleObjects _skillShowInvisibleObjects;
    private PlayerInput _playerInput;

    public void Initialize(bool skillOpen = true)
    {
        _skillShowInvisibleObjects = GetComponent<SkillShowInvisibleObjects>();
        SetDefaultSpawnPosition();
        _skillShowInvisibleObjects.Initlialize(skillOpen);
        _playerInput = GetComponent<PlayerInput>();
    }

    private void OnValidate()
    {
        _rigidbody??=GetComponent<Rigidbody>();
    }

    public void Update()
    {
        InteractableKeyInput();
        CheckDieZoneNegativeY();
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Physics.gravity * _rigidbody.mass);

        if (_interactable)
        {
            _interactable.InteractiveView.LookAtCamera();
        }
    }

    private void CheckDieZoneNegativeY()
    {
        if (transform.position.y < _dieZone)
        {
           Die(new DeathByFalling());
        }
    }

    private void SetDefaultSpawnPosition() => _spawnPoint = transform.position;

    private void InteractableKeyInput()
    {
        if (_interactable)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _interactable.OnInteract();
            }
        }
    }

    public async void Die(IDeathEffect deathEffect)
    {

        Debug.Log("strat");
        _playerInput.Disable();

        await StartEffect();

        Debug.Log("finish");
        _playerInput.Enable();

        Respawn();
        StopPlayer();
    }

    private async Task StartEffect()
    {
       await Task.Delay(2000);
    }

    public void Move(Vector3 move)
    {
        _rigidbody.AddForce(move, _forceMode);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable))
        {
            _interactable = interactable;
            _interactable.ShowMessage();
        }

        if (other.gameObject.TryGetComponent(out ICollectible collectebal))
        {
            if (other.gameObject.tag == "Key")
            {
                SaveHandler.instance.savesData.PickUpKey();
            }
            else
            {
                SaveHandler.instance.savesData.NewCoin();
            }
            
            SaveHandler.instance.Save();
            collectebal.Collect();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactable)
            _interactable.HideMessage();

        _interactable = null;
    }

    public void SetNewSpawPoint(Vector3 spawnPoint)
    {
        if (_spawnPoint != spawnPoint)
            _spawnPoint = spawnPoint;
    }

    private void Respawn() => transform.position = _spawnPoint;

    private void StopPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
 