using DG.Tweening;
using System;
using UnityEngine;

public class SkillShowInvisibleObjects : MonoBehaviour
{
    public event Action StopSkillAction;

    [SerializeField] private SkillView _skillView;
    [SerializeField] private float _timeOfAction;

    private bool _isUseSkill;
    private float _currentTime;
    private bool _isOpen;

    public bool isOpen=> _isOpen;

    public void Initlialize(bool isOpenSkill)
    {
        _isOpen = isOpenSkill;
        OpenSkill(_isOpen);
    }

    private void OpenSkill(object isOpen)
    {
        _skillView.ShowSkill(_isOpen);

        if (_isOpen)
        {
            _skillView.SetTimeAction(_timeOfAction);
        }
    }

    private void Update()
    {
        SkillKeyInput();

        if (_isUseSkill)
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

    public void ShowSkillInfo()
    {
        _skillView.ShowSkillInfo();
    }

    private void SkillKeyInput()
    {
        if (Input.GetKeyDown(KeyCode.F) && isOpen)
        {
            _isUseSkill = !_isUseSkill;

            if (_isUseSkill)
                Use();
            else
                SkillStop();
        }
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
        InvisibleMaterial[] invisibleMaterials = FindObjectsByType<InvisibleMaterial>(FindObjectsSortMode.None);
        foreach (InvisibleMaterial invisible in invisibleMaterials)
        {
            invisible.SetVisible();
        }
    }

}
