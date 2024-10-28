using DG.Tweening;
using UnityEngine;

public class Bridge : AnimationObject
{
    [SerializeField] private Ease _easeEffect;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _duration;

    private bool _isOpen;
    private float _doorClose;
    private float _doorOpen;

    private void Start()
    {
        _doorClose = transform.localPosition.y;
        _doorOpen = _endPosition;
    }

    public override void Action()
    {
        _isOpen = !_isOpen;
        float stateDoor = _doorClose;

        if (_isOpen)
            stateDoor = _doorOpen;

        StartAnimation(stateDoor);
    }

    private void StartAnimation(float stateDoor)
    {
       Debug.Log(stateDoor);
       transform.DOLocalMoveY(stateDoor, _duration).SetEase(_easeEffect);
    }

}
