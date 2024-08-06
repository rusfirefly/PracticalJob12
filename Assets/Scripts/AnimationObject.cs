using DG.Tweening;
using UnityEngine;

public class AnimationObject : MonoBehaviour, IInteract
{
    private enum TypeAnimation {DOMoveY, DOMoveX, DOMoveZ}

    [SerializeField] private Ease _easeEffect;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _duration;
    [SerializeField] private TypeAnimation _typeAnimation;
    [SerializeField] private Camera _camera;

    private bool _isOpen;
    private float _doorClose;
    private float _doorOpen;

    private void Start()
    {
        _doorClose = transform.localPosition.y;
        _doorOpen = _endPosition;
        _camera = Camera.main;
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
                transform.DOLocalMoveY(stateDoor, _duration).SetEase(_easeEffect);
                break;
            case TypeAnimation.DOMoveX:
                transform.DOLocalMoveX(stateDoor, _duration).SetEase(_easeEffect);
                break;
            case TypeAnimation.DOMoveZ:
                transform.DOLocalMoveZ(stateDoor, _duration).SetEase(_easeEffect);
                break;

        }
        
        _camera.DOShakePosition(2f, 10, 100, 90);
    }

}
