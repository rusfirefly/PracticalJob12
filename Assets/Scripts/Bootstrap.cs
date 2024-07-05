using UnityEngine;

public class Bootstrap : MonoBehaviour
{
    [SerializeField] private SaveHandler _saveHandler;

    private void Start()
    {
        _saveHandler.Initialized();
    }
}
