using UnityEngine;

public class FireDie : MonoBehaviour, IDieEffect
{
    public void StartDieEffect(Vector3 position)
    {
        Debug.Log("Fire Die");
    }
}
