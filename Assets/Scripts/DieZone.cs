using UnityEngine;

public class DieZone : MonoBehaviour
{

    [SerializeField] private DeathEffect _deathEffect;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            IDeathEffect deathEffect = (IDeathEffect)_deathEffect;
            player.Die(deathEffect);
        }
    }
}
