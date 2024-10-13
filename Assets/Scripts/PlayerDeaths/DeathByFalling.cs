using UnityEngine;

public class DeathByFalling : DeathEffect, IDeathEffect
{
    public void Die(Vector3 position)
    {
        Debug.Log("Falling");
    }
}
