using UnityEngine;

public class TriggerZone : Interactable
{
    [SerializeField] private AnimationObject _animationObject;
    
    private IInteract _objectInteract;

    private void Start()
    {
        _objectInteract = _animationObject.GetComponent<IInteract>();
    }

    public override void OnInteract()
    {
        if (_objectInteract != null)
        {
            _objectInteract.Action();
        }
    }
}
