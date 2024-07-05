using UnityEngine;
using System;

public class Coin : MonoBehaviour, ICollectible
{
    public static event Action Collectible;
    [SerializeField] private ParticleSystem _collectedEffect;

    public void Collect()
    {
        Debug.Log("collected coin");
        Collectible?.Invoke();
        Destroy(gameObject);
    }
}
