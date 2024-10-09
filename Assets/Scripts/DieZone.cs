using UnityEngine;

public class DieZone : MonoBehaviour
{
    [SerializeField] private DieEffect _dieEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            //player.Die(_dieEffect);

            player.Die();
        }
    }
}
