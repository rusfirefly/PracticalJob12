using UnityEngine;

public abstract class ParticalsHandler : MonoBehaviour
{
    [SerializeField] protected new ParticleSystem particleSystem;

    public void PlayPartical()
    {
        if(particleSystem.isStopped == true)
        {
            particleSystem.Play();
        }
    }

    public void StopPartical()
    {
       particleSystem.Stop();
    }
}
