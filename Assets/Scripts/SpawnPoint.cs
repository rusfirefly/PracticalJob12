using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [field: SerializeField] public Transform SpawnPosition { get; private set; }
    private bool _isActiveSpawnPoint;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player plyer))
        {
            Debug.Log("точка сохранения");
            if (_isActiveSpawnPoint == false)
            {
                plyer.SetNewSpawPoint(SpawnPosition.position);
                _isActiveSpawnPoint = true;
            }
        }
    }
}
