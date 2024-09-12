using UnityEngine;

public class TutorialBlock : MonoBehaviour
{
    [SerializeField] private Rigidbody _block;
    private bool _isTriger;

    private void OnTriggerEnter(Collider other)
    {
        CrashBlock();
    }

    private void CrashBlock()
    {
       if(_isTriger == false)
       {
            _isTriger = true;
            _block.isKinematic = false;

            Destroy(_block, 3.5f);
        }
    }

    private void FixedObject()
    {
        Destroy(_block);
    }

}
