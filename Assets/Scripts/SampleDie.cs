using UnityEngine;

public class SampleDie : MonoBehaviour, IDieEffect
{

    public void StartDieEffect(Vector3 position)
    {
        Debug.Log("Sample Die");    
    }
}
