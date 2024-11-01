using Cinemachine;
using UnityEngine;

public class MouseLook : MonoBehaviour, IPaused
{
    private enum MouseButton { ClickLook = 1 }
    [SerializeField] private CinemachineFreeLook _freeLook;
    private float _speed;
    private float _defaulSpeed;

    public bool IsPaused { get; set; }

    private void Awake()
    {
        _defaulSpeed = _freeLook.m_XAxis.m_MaxSpeed;
        SetMaxSpeed(0);
    }

    private void Update()
    {
        if (IsPaused) return;

        if(Input.GetMouseButtonDown((int)MouseButton.ClickLook))
        {
            _speed = _defaulSpeed;
        }
        else
        {
            if(Input.GetMouseButtonUp((int)MouseButton.ClickLook))
            {
                _speed = 0;
            }
        }

        SetMaxSpeed(_speed);
    }

    private void SetMaxSpeed(float speed) => _freeLook.m_XAxis.m_MaxSpeed = speed;

    public void Pause()
    {
        IsPaused = true;
    }

    public void Resume()
    {
        IsPaused=false;
    }
}
