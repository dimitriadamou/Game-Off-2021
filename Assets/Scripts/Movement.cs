using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
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
                transform.position + (Vector3.up * Time.deltaTime * 10)
            );
        }

        if(Input.GetKey(KeyCode.DownArrow)) {
            rigidBody.MovePosition(
                transform.position - (Vector3.up * Time.deltaTime * 10)
            );
        }
    }
}
