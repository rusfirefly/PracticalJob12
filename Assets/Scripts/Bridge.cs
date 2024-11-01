using DG.Tweening;
using UnityEngine;

public class Bridge : AnimationObject, IPaused
{
    [SerializeField] private Ease _easeEffect;
    [SerializeField] private float _endPosition;
    [SerializeField] private float _duration;

    private bool _isOpen;
    private float _doorClose;
    private float _doorOpen;
    private Tween _tween;
    public bool IsPaused { get; set; }

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
      _tween = transform.DOLocalMoveY(stateDoor, _duration).SetEase(_easeEffect);
    }

    public void Pause()
    {
        IsPaused = true;
        _tween.Pause();
    }

    public void Resume()
    {
        IsPaused = false;
        _tween.Play();
    }
}
