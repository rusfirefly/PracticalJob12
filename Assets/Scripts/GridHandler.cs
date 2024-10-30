using System.Collections.Generic;
using UnityEngine;

public class GridHandler : MonoBehaviour
{
    [SerializeField] private List<ParticleSystem> _particleSystems;

    public void Enable()
    {
        if (_particleSystems.Count > 0)
        {
            foreach (ParticleSystem partical in _particleSystems)
            {
                if (partical.isStopped)
                {
                    partical.Play();
                }
            }
        }
    }
}
