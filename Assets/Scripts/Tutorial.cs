using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private bool _isOpenSkill;

    private void Start()
    {
        _player.Initialize(skillOpen: _isOpenSkill);
    }


}
