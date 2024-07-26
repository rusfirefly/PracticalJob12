using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Text _skillTimeOfActionText;

    public void SetTimeAction(float time)
    {
        _skillTimeOfActionText.text = $"{time:F0}";
    }
}
