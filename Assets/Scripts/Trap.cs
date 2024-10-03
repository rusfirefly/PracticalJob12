using DG.Tweening;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] Transform[] _positions;
    [SerializeField] private bool _isStart;

    private int _positionIndex = 0;
    private Vector3 _position;
    private bool _isEnd;

    private void Update()
    {
        if(_isStart == false) return;

        Mathf.Clamp(_positionIndex++,0, _positions.Length);

        Debug.Log(_positionIndex);
    }

    public void Enabele() => _isStart = true;

    public void Disabele() => _isStart = false;

    private Vector3 NextPoint() => _positions[_positionIndex++].transform.position;

    private Vector3 PreviousPoint()=> _positions[_positionIndex--].transform.position;


}
