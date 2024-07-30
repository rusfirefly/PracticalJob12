using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Text _skillTimeOfActionText;
    private bool _isOpen;

    public void SetTimeAction(float time)
    {
        _skillTimeOfActionText.text = $"{time:F0}";
    }

    public void ShowSkill(bool isOpen)=>  gameObject.SetActive(isOpen);
}
