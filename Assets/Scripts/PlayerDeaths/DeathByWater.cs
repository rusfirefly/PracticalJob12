using UnityEngine;

public class DeathByWater : DeathEffect, IDeathEffect
{
    public void Die(Vector3 position)
    {
        Debug.Log("water");
    }
}
