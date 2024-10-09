using System.Collections.Generic;
using UnityEngine;

public class DieEffect : MonoBehaviour, IDieEffect
{
    [SerializeField] private List<ParticleSystem> _dieEffects;

    public void Initialize(Transform playerPosition)
    {

    }

    public void StartEffect()
    {
        
    }
}
