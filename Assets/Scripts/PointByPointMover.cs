using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointByPointMover : MonoBehaviour, IPaused
{
    [SerializeField] AnimationCurve _movementCurve;
    [SerializeField] private float _speed;
    [SerializeField] private float _coldownBetweenMoves;

    private Queue<Vector3> _currentPath;
    private Vector3 _currentPoint;

    public bool IsPaused { get; set; }

    public void Initialized(IEnumerable<Vector3> path)
    {
        _currentPath = new Queue<Vector3>(path);
        StartCoroutine(ProcessMove());
    }

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused = false;
    }

    private IEnumerator ProcessMove()
    {
        Vector3 startPoint;
        float progress = 0;

        while(_currentPath.Count > 0)
        {
            if (IsPaused)
            {
                yield return null;
            }


            SwitchPoint();

            startPoint = transform.position;

            while(progress < 1)
            {
                progress += Time.deltaTime * _speed;
                transform.position = Vector3.LerpUnclamped(startPoint, _currentPoint, _movementCurve.Evaluate(progress));
                yield return null;
            }

            transform.position = _currentPoint;
            progress = 0;

            yield return new WaitForSeconds(_coldownBetweenMoves);
        }
    }

    private void SwitchPoint()
    {
        _currentPoint = _currentPath.Dequeue();
        _currentPath.Enqueue(_currentPoint);
    }
}
