using System.Collections;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private bool _isMainMenu;
    
    private int _sceneID;

    private async void Start()
    {
        if (_isMainMenu) return;
        int? portalId = SaveHandler.Instance.SavedData.DataGame.PortalID;

        if (portalId == null)
        {
            _sceneID = SaveHandler.Instance.SavedData.GetLevelID;
        }
        else
        {
            _sceneID = (int)portalId;
        }

        await Task.Delay(2500);
        Load(_sceneID);
    }

    public void Load(int sceneId)
    {
        _sceneID = sceneId;
        StartCoroutine(AsynkLoad());
    }

    public void Load()
    {
        StartCoroutine(AsynkLoad());
    }

    private IEnumerator AsynkLoad()
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(_sceneID);

        while (asynkLoad.isDone == false)
        {
            yield return null;
        }
    }
}
