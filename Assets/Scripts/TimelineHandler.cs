using UnityEngine;
using UnityEngine.Playables;

public class TimelineHandler : MonoBehaviour
{
    private PlayableDirector _playableDirector;

    private void OnValidate()
    {
        _playableDirector??=GetComponent<PlayableDirector>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _playableDirector.Play();
    }
}
