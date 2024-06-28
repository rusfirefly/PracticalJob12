using System;
using TMPro;
using UnityEngine;

public class Platform : MonoBehaviour
{
    [SerializeField] private GameObject _door;
    private IInteract _doorInteraction;

    private void Start()
    {
        _doorInteraction = _door.GetComponent<IInteract>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _doorInteraction.Action();
    }

    private void OnTriggerExit(Collider other)
    {
        _doorInteraction.Action();
    }
}
