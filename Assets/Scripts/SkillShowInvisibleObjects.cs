using System;
using System.Collections;
using UnityEngine;

public class SkillShowInvisibleObjects : MonoBehaviour
{
    public event Action StopSkillAction;
    [SerializeField] private SkillView _skillView;
    [SerializeField] private float _timeOfAction;

    private bool _isUseSkill;
    private float _currentTime;


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
        SetVisibleAllHideObjects(_isUseSkill);
    }

    public void SkillStop()
    {
        _isUseSkill = false;
        SetVisibleAllHideObjects(_isUseSkill);
    }

    private void ColdownSkill()
    {
        _currentTime += Time.deltaTime;
        _skillView.Animation(_timeOfAction - _currentTime);
        if (_currentTime > _timeOfAction)
        {
            _isUseSkill = false;
            StopSkillAction?.Invoke();
            SetVisibleAllHideObjects(_isUseSkill);
        }
    }

    private void ReloadSkill()
    {
        if (TryTime())
        {
            _currentTime -= Time.deltaTime;
            _skillView.Animation(_timeOfAction - _currentTime);
        }else
        {
            _currentTime = 0;
        }
    }

    private bool TryTime()
    {
        if((_timeOfAction - _currentTime) < _timeOfAction)
        {
            return true;
        }
        return false;
    }

    private void SetVisibleAllHideObjects(bool visible)
    {
        InvisibleMaterial[] invisibleMaterials = FindObjectsOfType<InvisibleMaterial>();
        foreach (InvisibleMaterial invisible in invisibleMaterials)
        {
            invisible.SetVisible(visible);
        }
    }

}
