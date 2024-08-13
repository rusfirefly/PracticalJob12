using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Text _skillTimeOfActionText;
    [SerializeField] private Canvas _skillInfo;

    private bool _isOpen;
    private int _puseon = 0;
    private int _puseoff = 1;

    public void SetTimeAction(float time)
    {
        _skillTimeOfActionText.text = $"{time:F0}";
    }

    public void ShowSkill(bool isOpen)=>  gameObject.SetActive(isOpen);

    public void ShowSkillInfo()
    {
        _skillInfo.gameObject.SetActive(true);
        SetPauseGame(pause:true);
    }

    public void SetPauseGame(bool pause)
    {
        Time.timeScale = pause ? _puseon : _puseoff;
    }

}
