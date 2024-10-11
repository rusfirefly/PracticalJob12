using UnityEngine;

public enum TypeZone { Enemy, Water, Ice, Fire, Electro, Acid/*кислота*/, Unknow, Height }

public class DieZone : MonoBehaviour
{
    [SerializeField] private TypeZone _typeZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            player.Die(_typeZone);
        }
    }
}
