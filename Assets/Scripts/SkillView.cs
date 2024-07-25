using UnityEngine;
using UnityEngine.UI;

public class SkillView : MonoBehaviour
{
    [SerializeField] private Text _skillTimeOfActionText;

    public void Animation(float time)
    {
        _skillTimeOfActionText.text = $"{time:F0}";
    }
}
