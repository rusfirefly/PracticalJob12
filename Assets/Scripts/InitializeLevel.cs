using UnityEngine;

public class InitializeLevel : MonoBehaviour
{
    [SerializeField] private SaveHandler _saveHandler;

    private void Start()
    {
        _saveHandler.Singlton();
    }
}
