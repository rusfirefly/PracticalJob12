using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Tutorial _tutorial;
    [SerializeField] private float _timeOnVisible;
    private int _tutorialCount;
    private int _nextTutorial;

    private void OnTriggerEnter(Collider other)
    {
        if (_tutorial == null)
        {
            Close();
            return;
        }
        Next();
        Invoke("Close", _timeOnVisible);
    }

    private void Close()
    {
        gameObject.SetActive(false); 
    }

    private void Next()
    {
       ShowTutorial(_nextTutorial); 
    }

    private void ShowTutorial(int index) => _tutorial.gameObject.SetActive(true);
}
