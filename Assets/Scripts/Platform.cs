using UnityEngine;

public class Platform : ParticalsHandler
{
    [SerializeField] private AnimationObject _animationObject;

    private IInteract _doorInteraction;

    private void Start()
    {
        _doorInteraction = _animationObject.GetComponent<IInteract>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _doorInteraction.Action();

        if(particleSystem != null)
        {
            PlayPartical();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _doorInteraction.Action();

        if (particleSystem != null)
        {
            StopPartical();
        }
    }


}
