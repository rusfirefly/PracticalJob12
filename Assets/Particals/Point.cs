using System;
using System.Collections;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static event Action PointComplete;
    
    [SerializeField] private MeshRenderer _meshRender;
    [SerializeField] private bool _isEnable;
    [SerializeField] private float _timerDisablePartical = 3f;
    private ParticleSystem[] _particals;
    private float _timeOnEnableLight = 0.1f;
    private float _newAlpha = 15;
    private int _maxPartical=2;

    private void Start()
    {
        _particals = GetComponentsInChildren<ParticleSystem>();
        
        if (_isEnable)
        {
            Show();
        }
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(HidePartical());
    }

    public void Show()
    {
        foreach(ParticleSystem partical in _particals)
        {
            partical.Play();
        }

        StartCoroutine(ColdownPilar());
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void ShowPilar()
    {
        _meshRender.enabled = true;
    }
   
    private IEnumerator ColdownPilar()
    {

       yield return new WaitForSeconds(_timeOnEnableLight);
        ShowPilar();
    }

    [System.Obsolete]
    private IEnumerator HidePartical()
    {
        if (_particals.Length < 1) yield return null;

        _meshRender.enabled = false;
        _particals[0].maxParticles = _maxPartical;
        Color color = _particals[1].startColor;
        color.a = _newAlpha;
        ChangeAlpha(color);
        yield return new WaitForSeconds(_timerDisablePartical);
        PointComplete?.Invoke();
        Hide();
    }

    [System.Obsolete]
    private void ChangeAlpha(Color color)
    {
        _particals[1].startColor = color;
        _particals[2].startColor = color;
    }
}
