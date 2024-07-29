using UnityEngine;

public class TriggerZone : Interactable
{
    [SerializeField] private GameObject _object;
    
    private IInteract _objectInteract;

    private void Start()
    {
        _objectInteract = _object.GetComponent<IInteract>();
    }

    public override void OnInteract()
    {
        if (_objectInteract != null)
        {
            _objectInteract.Action();
        }
    }
}
