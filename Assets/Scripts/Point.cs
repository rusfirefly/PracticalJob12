using System;
using System.Collections;
using UnityEngine;

public class Point : MonoBehaviour
{
    public static event Action PointComplete;
    
    [SerializeField] private bool _isEnable;
    [SerializeField] private float _timerDisablePartical = 3f;
    private ParticleSystem[] _particals;
    private BoxCollider _boxColliderTriger;
    private float _timeOnEnableLight = 0.1f;
    private float _newAlpha = 15;
    private int _maxPartical=2;

    private void Awake()
    {
        _particals = GetComponentsInChildren<ParticleSystem>();
        _boxColliderTriger = GetComponent<BoxCollider>();

        SetStateTrigger(false);

        if (_isEnable)
        {
            Show();
        }
    }

    private void OnValidate()
    {
        _boxColliderTriger??=GetComponent<BoxCollider>();
    }

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(HidePartical());
    }

    public void Show()
    {
        SetStateTrigger(true);

        foreach (ParticleSystem partical in _particals)
        {
            partical.Play();
        }
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    [System.Obsolete]
    private IEnumerator HidePartical()
    {
        if (_particals.Length < 1)
        {
            yield return null;
        }

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

    private void SetStateTrigger(bool isState)
    {
        _boxColliderTriger.enabled = isState;
    }
}
