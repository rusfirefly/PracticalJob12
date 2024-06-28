using UnityEngine;

public class DieZone : MonoBehaviour
{
    private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        _player = other.GetComponent<Player>();

        if(_player)
        {
            _player.Die();
        }
    }
}
