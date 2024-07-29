using System;
using UnityEngine;

public class SkillShowInvisibleObjects : MonoBehaviour
{
    public event Action StopSkillAction;
    [SerializeField] private SkillView _skillView;
    [SerializeField] private float _timeOfAction;

    private bool _isUseSkill;
    private float _currentTime;

    private void Start()
    {
        _skillView.SetTimeAction(_timeOfAction);
    }

    private void Update()
    {
        if(_isUseSkill)
        {
            ColdownSkill();
        } 
        else
        {
            ReloadSkill();
        }
    }

    public void Use()
    {
        _isUseSkill = true;
        SetVisibleAllHideObjects();
    }

    public void SkillStop()
    {
        _isUseSkill = false;
        SetVisibleAllHideObjects();
    }

    private void ColdownSkill()
    {
        _currentTime += Time.deltaTime;
        _skillView.SetTimeAction(_timeOfAction - _currentTime);
        if (_currentTime > _timeOfAction)
        {
            _isUseSkill = false;
            SetVisibleAllHideObjects();
            StopSkillAction?.Invoke();
        }
    }

    private void ReloadSkill()
    {
        if (TryTimeAction())
        {
            _currentTime -= Time.deltaTime;
            _skillView.SetTimeAction(_timeOfAction - _currentTime);
        }else
        {
            _currentTime = 0;
        }
    }

    private bool TryTimeAction()
    {
        if((_timeOfAction - _currentTime) < _timeOfAction)
        {
            return true;
        }
        return false;
    }

    private void SetVisibleAllHideObjects()
    {
        InvisibleMaterial[] invisibleMaterials = FindObjectsOfType<InvisibleMaterial>();
        foreach (InvisibleMaterial invisible in invisibleMaterials)
        {
            invisible.SetVisible();
        }
    }

}
