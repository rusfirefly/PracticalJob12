using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Text _skillTimeOfActionText;
    [SerializeField] private Canvas _skillInfo;

    private bool _isOpen;
    private List<IPaused> _pausedObjects;

    private void Start()
    {
       _pausedObjects = FindObjectsByType<MonoBehaviour>(FindObjectsSortMode.None).OfType<IPaused>().ToList();
    }

    public void SetTimeAction(float time)
    {
        _skillTimeOfActionText.text = $"{time:F0}";
    }

    public void ShowSkill(bool isOpen) =>  gameObject.SetActive(isOpen);

    public void ShowSkillInfo()
    {
        _skillInfo.gameObject.SetActive(true);
        SetPauseGame(pause:true);
    }

    public void SetPauseGame(bool pause)
    {
        Cursor.lockState = pause ? CursorLockMode.Confined:CursorLockMode.Locked;
                   
        foreach(IPaused pausedObject in _pausedObjects)
        {
            if (pause)
            {
                pausedObject.Pause();
            }else
            {
                pausedObject.Resume();
            }
        }
    }

}
