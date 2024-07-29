using DG.Tweening;
using UnityEngine;

public class Door : MonoBehaviour, IInteract
{
    private enum TypeAnimation {DOMoveY, DOMoveX, DOMoveZ}

    [SerializeField] private Ease _easeEffect;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _duration;
    [SerializeField] private TypeAnimation _typeAnimation;

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

        if (_isOpen)
            stateDoor = _doorOpen;

        StartAnimation(stateDoor);
    }

    private void StartAnimation(float stateDoor)
    {
        switch (_typeAnimation)
        {
            case TypeAnimation.DOMoveY:
                transform.DOMoveY(stateDoor, _duration).SetEase(_easeEffect);
                break;
            case TypeAnimation.DOMoveX:
                transform.DOMoveX(stateDoor, _duration).SetEase(_easeEffect);
                break;
            case TypeAnimation.DOMoveZ:
                transform.DOMoveZ(stateDoor, _duration).SetEase(_easeEffect);
                break;

        }
    }

}
