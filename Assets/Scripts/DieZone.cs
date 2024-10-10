using UnityEngine;

public class DieZone : MonoBehaviour
{
    private enum TypeZone {Enemy, Water, Ice, Fire, Electro, Acid/*кислота*/, Unknow}

    [SerializeField] private TypeZone _typeZone;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.TryGetComponent(out Player player))
        {
            IDieEffect effect = new SampleDie();

            switch(_typeZone)
            {
                case TypeZone.Water:
                    effect = new SampleDie();
                    break;
                case TypeZone.Fire:
                    effect = new FireDie();
                    break;
            }

           player.Die(effect);
        }
    }
}
