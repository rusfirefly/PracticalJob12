using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action Collectible;
    [SerializeField] private ParticleSystem _particleSystem;
    private float _timeOut = 2.5f;
    private bool _isCollected;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();
    }

    public void Collect()
    {
        if (_isCollected) return;

        Collectible?.Invoke();
        _meshRenderer.enabled = false;
        _isCollected = true;
        StartParticalEffect();
        Destroy(gameObject, _timeOut);
    }

    private void StartParticalEffect() => _particleSystem.Play();
}
