using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SkillShowInvisibleObjects))]

public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ForceMode _forceMode;
    [SerializeField] private float _dieZone;

    private Vector3 _spawnPoint;
    private Interactable _interactable;
    private bool _isActiveSkill;
    private SkillShowInvisibleObjects _skillShowInvisibleObjects;

    private void Start()
    {
        _skillShowInvisibleObjects = GetComponent<SkillShowInvisibleObjects>();
        _skillShowInvisibleObjects.StopSkillAction += OnStopSkillAction;
        SetDefaultSpawnPosition();
    }

    private void OnDisable()
    {
        _skillShowInvisibleObjects.StopSkillAction -= OnStopSkillAction;
    }

    private void OnValidate()
    {
        _rigidbody??=GetComponent<Rigidbody>();
    }

    public void Update()
    {
        InteractableKeyInput();
        SkillKeyInput();

        if (transform.position.y < _dieZone)
        {
            Die();
        }
    }

    private void SetDefaultSpawnPosition() => _spawnPoint = transform.position;

    private void SkillKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            _isActiveSkill = !_isActiveSkill;

            if (_isActiveSkill)
                _skillShowInvisibleObjects.Use();
            else
                _skillShowInvisibleObjects.SkillStop();
        }
    }

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
        Respawn();
        StopPlayer();
    }

    public void Move(Vector3 move)
    {
        _rigidbody.AddForce(move, _forceMode);
    }

    private void OnStopSkillAction()
    {
        _isActiveSkill = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Interactable interactable))
        {
            _interactable = interactable;
            _interactable.ShowMessage();
        }

        if (other.gameObject.TryGetComponent(out ICollectible coin))
        {
            SaveHandler.instance.savesData.NewCoin();
            SaveHandler.instance.Save();

            coin.Collect();
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
