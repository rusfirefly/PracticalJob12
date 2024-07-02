using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Player : MonoBehaviour, IMovable
{
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private ForceMode _forceMode;
    private Interactable _interactable;

    private void OnValidate()
    {
        _rigidbody??=GetComponent<Rigidbody>();
    }

    public void Update()
    {
        if(_interactable)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                _interactable.OnInteract();
            }
        }
    }

    public void Die()
    {
        Debug.Log("Game Over!");
    }

    public void Move(Vector3 move)
    {
        _rigidbody.AddRelativeForce(move, _forceMode);
    }

    public void LookInDirection(Vector3 newForward)
    {
        transform.forward = newForward;
    }

    private void OnTriggerEnter(Collider other)
    {
        _interactable = other.GetComponent<Interactable>();

        if(_interactable)
        {
            _interactable.ShowMessage();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (_interactable)
        {
            _interactable.HideMessage();
        }

        _interactable = null;
    }
}
