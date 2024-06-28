
using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteract
{
    [SerializeField] private Ease _easeEffect;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _duration;
    private bool _isOpen;
    private float _doorClose;
    private float _doorOpen;

    private void Start()
    {
        _doorClose = transform.position.y;
        _doorOpen = _endPosition;
    }

    public void Action()
    {
        _isOpen = !_isOpen;
        float stateDoor = _doorClose;
        if(_isOpen)
            stateDoor = _doorOpen;

        transform.DOMoveY(stateDoor, _duration).SetEase(_easeEffect);
    }

    
}
