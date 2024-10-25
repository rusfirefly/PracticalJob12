using UnityEngine;

public class DoorTrigger : Interactable
{
    [SerializeField] private ParticleSystem _particleSystem;
    private bool _isOpenDoor;

    public override void OnInteract()
    {
        if (SaveHandler.Instance.SavedData.IsKey == false) return;

        if (_isOpenDoor) return;

        _particleSystem.Play();
        _isOpenDoor = true;

        Destroy(gameObject, 2.5f);
    }
}
