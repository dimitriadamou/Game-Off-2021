using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SharedVector3 playerLocation;
    [SerializeField] Camera activeCamera;
    Rigidbody rigidBody;

    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Input.GetKey(KeyCode.UpArrow)) {
            rigidBody.MovePosition(
                transform.position + (Vector3.up * Time.deltaTime)
            );
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            rigidBody.MovePosition(
                transform.position - (Vector3.up * Time.deltaTime)
            );
        }

        playerLocation.Value = this.transform.position;
    }
}
