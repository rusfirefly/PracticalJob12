using UnityEngine;

public class AbilityItem : MonoBehaviour
{
    [SerializeField] private SkillShowInvisibleObjects _skillPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            _skillPlayer.Initlialize(isOpenSkill: true);
            _skillPlayer.ShowSkillInfo();
            DestroyObject();
        }
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
