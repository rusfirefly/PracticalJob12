using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Analytics;
using static UnityEngine.Rendering.DebugUI;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SkillShowInvisibleObjects))]

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _dieZone;

    private Rigidbody _rigidbody;
    private Vector3 _spawnPoint;
    private Interactable _interactable;
    private SkillShowInvisibleObjects _skillShowInvisibleObjects;
    private PlayerInput _playerInput;
    private Animator _animator;
    private PlayerDeathEffect _playerDeathEffect;

    public void Initialize(bool skillOpen = true)
    {
        _skillShowInvisibleObjects = GetComponent<SkillShowInvisibleObjects>();
        SetDefaultSpawnPosition();
        _skillShowInvisibleObjects.Initlialize(skillOpen);
        _playerInput = GetComponent<PlayerInput>();
        _animator = GetComponent<Animator>();
        _playerDeathEffect = new PlayerDeathEffect(_playerInput, _animator, _rigidbody);
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
            Die();
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

    public void Die()
    {
        _playerDeathEffect.Die(transform, _spawnPoint);
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
}
 