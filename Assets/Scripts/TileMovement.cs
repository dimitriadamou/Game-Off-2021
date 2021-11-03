using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMovement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SharedVector3 playerLocation;

    Vector3 originalPosition;
    Vector3 originalPositionNoZ;
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

        originalPositionNoZ = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y            
        );
    }

    // Update is called once per frame
    private float deltaTime;
    void Update()
    {

        var playerVec = new Vector3(
            playerLocation.Value.x,
            playerLocation.Value.y
        );

        var yPos = playerVec.y - originalPositionNoZ.y;

        var distance = Mathf.Clamp(
            Vector3.Distance(
                new Vector3(
                    playerLocation.Value.x,
                    playerLocation.Value.y
                ),
                new Vector3(
                    originalPosition.x,
                    originalPosition.y
                )                        
            ),
            0,
            15
        );

        transform.localPosition = new Vector3(
            transform.localPosition.x,
            transform.localPosition.y,
            Mathf.Lerp(
                originalPosition.z,
                yPos < 0 ? -10f : 30f,
                yPos < 0 ? ( (distance - 10) / 10)  : ( (distance - 5) / 5)
            )
        );    
    }

    private void OnTriggerEnter(Collider other) {

        if ( other.tag == "Player" ) {
        //targetPosition = originalPosition;
        }
    }


    private void OnTriggerExit(Collider other) {
        /*
        if( other.tag == "Player" ) {
            targetPosition = transform.localPosition;
            targetPosition.z = 20;
        }
        */
    }

}
