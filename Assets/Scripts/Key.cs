using UnityEngine;

public class Key : MonoBehaviour, ICollectible
{
    [SerializeField] private HudHandler _hudHandler;
    [SerializeField] private ParticleSystem _particleSystem;

    private bool _isKeyPickUp;
    private MeshRenderer _meshRenderer;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();    
    }

    public void Collect()
    {
        if(_isKeyPickUp == false)
        {
            _meshRenderer.enabled = false;
            _particleSystem.Play();
            _hudHandler.ShomMessageKey();
            _isKeyPickUp = true;
            Destroy(gameObject, 2.5f);
        }
    }
}
