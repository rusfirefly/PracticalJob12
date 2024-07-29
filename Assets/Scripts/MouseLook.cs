using Cinemachine;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    
    [SerializeField] private CinemachineFreeLook _freeLook;
    private float _speed;
    private float _defaulSpeed;

    private void Awake()
    {
        _defaulSpeed = _freeLook.m_XAxis.m_MaxSpeed;
        SetMaxSpeed(0);
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            _speed = _defaulSpeed;
        }
        else
        {
            if(Input.GetMouseButtonUp(1))
            {
                _speed = 0;
            }
        }

        SetMaxSpeed(_speed);
    }

    private void SetMaxSpeed(float speed) => _freeLook.m_XAxis.m_MaxSpeed = speed;

}
