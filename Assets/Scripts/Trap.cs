using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private PointByPointMover _mover;
    [SerializeField] private bool _isStart;

    private bool _isEnd;

    private void Start()
    {
        if(_isStart)
        {
            Enabele();
        }
    }

    public void Enabele()
    {
        _mover.Initialized(_points.Select(point => point.transform.position));
    }
}