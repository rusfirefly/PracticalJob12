using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BridgeWithAnimation : AnimationObject
{
    [SerializeField] private Animator _animator;
    [SerializeField] string _nameAnimation;

    private bool _isPlaying;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnValidate()
    {
        _animator ??= GetComponent<Animator>();
    }

    public override void Action()
    {
        _isPlaying  =! _isPlaying;
        StartAnimation();
    }

    private void StartAnimation()
    {
        _animator.SetBool(_nameAnimation, _isPlaying);
    }
}
