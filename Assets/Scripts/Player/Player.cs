using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SkillShowInvisibleObjects))]

public class Player : MonoBehaviour, IMovable, IPaused
{
    [SerializeField] private ForceMode _forceMode;

    private Rigidbody _rigidbody;
    private Vector3 _spawnPoint;
    private Interactable _interactable;
    private SkillShowInvisibleObjects _skillShowInvisibleObjects;
    private PlayerInput _playerInput;
    private Animator _animator;
    private PlayerDeathEffect _playerDeathEffect;

    public bool IsPaused { get; set; }

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
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(Physics.gravity * _rigidbody.mass);

        if (_interactable)
        {
            _interactable.InteractiveView.LookAtCamera();
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
                SaveHandler.Instance.SavedData.PickUpKey();
            }
            else
            {
                SaveHandler.Instance.SavedData.NewCoin();
            }
            
//            SaveHandler.Instance.Save();
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

    public void Pause()
    {
        IsPaused = true;
        StopPlayer();
    }

    public void Resume()
    {
       IsPaused = false;
    }

    private void StopPlayer()
    {
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
 