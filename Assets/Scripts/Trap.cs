using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] private List<Transform> _points;
    [SerializeField] private PointByPointMover _mover;

    private bool _isEnd;

    public void Enabele()
    {
        _mover.Initialized(_points.Select(point => point.transform.position));
    }
}