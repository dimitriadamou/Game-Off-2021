using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    // Start is called before the first frame update

    Vector3 originalPosition;
    Vector3 targetPosition;

    int playerMask = 0;
    int playerTag = 0;
    void Start()
    {
        playerMask = LayerMask.GetMask("Player Object");
        targetPosition = originalPosition = transform.localPosition;
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            -30
        );
    }

    // Update is called once per frame
    private float deltaTime;
    void Update()
    {
        
        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            Mathf.Lerp(
                transform.localPosition.z,
                targetPosition.z,
                Time.deltaTime
            )
        );    
    }

    private void OnTriggerEnter(Collider other) {

        if ( other.tag == "Player" ) {
        targetPosition = originalPosition;
        }
    }


    private void OnTriggerExit(Collider other) {
        if( other.tag == "Player" ) {
            targetPosition = transform.localPosition;
            targetPosition.z = 20;
        }
    }

}
