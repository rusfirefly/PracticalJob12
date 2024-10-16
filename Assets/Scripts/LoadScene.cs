using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    [SerializeField] private string _sceneName;

    private void Awake()
    {
        Load();
    }

    public void Load()
    {
        StartCoroutine(AsynkLoad());
    }

    private IEnumerator AsynkLoad()
    {
        AsyncOperation asynkLoad = SceneManager.LoadSceneAsync(_sceneName);

        while (asynkLoad.isDone == false)
        {
            Debug.Log(asynkLoad.progress);
            yield return null;
        }
    }
}
