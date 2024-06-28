using UnityEngine;

public enum Zone {Press, PutObject};

public class TriggerZone : Interactable
{
    [SerializeField] private GameObject _object;
    private IInteract _objectInteract;
    private Zone _zone;

    private void Start()
    {
        _objectInteract = _object.GetComponent<IInteract>();
    }

    public override void OnInteract()
    {
        if (_zone == Zone.Press)
        {
            base.OnInteract();
        }

        if (_objectInteract != null)
        {
            _objectInteract.Action();
        }
    }
}
