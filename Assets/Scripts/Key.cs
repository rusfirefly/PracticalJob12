using UnityEngine;
using UnityEngine.Playables;

public class Key : MonoBehaviour, ICollectible
{
    [SerializeField] private HudHandler _hudHandler;
    [SerializeField] private ParticleSystem _particleSystem;
    [SerializeField] private PlayableDirector _timeLine;

    private bool _isKeyPickUp;
    private MeshRenderer _meshRenderer;
    private float _timeOut = 2.5f;

    private void Start()
    {
        _meshRenderer = GetComponent<MeshRenderer>();    
    }

    public void Collect()
    {
        if(_isKeyPickUp == false)
        {
            _meshRenderer.enabled = false;
            StartParticalEffect();
            _hudHandler.ShomMessageKey();
            _isKeyPickUp = true;
            Invoke("PlayeTimeLine", 0.5f);
            Destroy(gameObject, _timeOut);
        }
    }

    private void PlayeTimeLine() => _timeLine.Play();

    private void StartParticalEffect()=>_particleSystem.Play();

}
