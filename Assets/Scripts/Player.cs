using DG.Tweening;
using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
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
        if(_interactable)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _interactable.OnInteract();
            }
        }

        if(Input.GetKeyDown(KeyCode.F))
        {
            _isActiveSkill = !_isActiveSkill;
            Debug.Log(_isActiveSkill);
            if (_isActiveSkill)
                _skillShowInvisibleObjects.Use();
            else
                _skillShowInvisibleObjects.SkillStop();
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

    private void OnStopSkillAction()
    {
        _isActiveSkill = false;
        _skillShowInvisibleObjects.SkillStop();
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
    }

    public void SetNewSpawPoint(Vector3 spawnPoint)
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

    private void Respawn() => transform.position = _spawnPoint;

    private void StopPlayer()
    {
        _rigidbody.velocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}
