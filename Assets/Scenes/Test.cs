using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]

public class Test : MonoBehaviour
{
    [SerializeField] private Camera _camera;
    private Rigidbody _rigidbody;

    private void OnValidate()
    {
        _rigidbody ??= GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal,0,moveVertical);
        _rigidbody.AddForce(movement * 10f);

        if(Input.GetMouseButton(1))
        {
            Debug.Log("ok");
            Vector3 cameraForward = _camera.transform.forward;
            cameraForward.y = 0;
            cameraForward.Normalize();

            Quaternion targetRotation = Quaternion.LookRotation(cameraForward);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 5f * Time.deltaTime);

        }
    }

}
