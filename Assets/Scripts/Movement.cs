using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SharedVector3 playerLocation;
    [SerializeField] Animator animator;
    Rigidbody rigidBody;

    private bool isMoving = false;
    private Vector3 destination;
    private Vector3 jumpPosition;
    private float jumpTime = 0f;

    void Start()
    {
        destination = Vector3.zero;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if(!isMoving && Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("IsMoving", true);
            isMoving = true;
            jumpTime = 0f;

            jumpPosition = this.transform.position;
            destination = this.transform.position + (Vector3.up * 3);
        } 


        if(isMoving) {
            jumpTime += Time.deltaTime * 5;
            rigidBody.MovePosition(
                Vector3.Lerp(
                    jumpPosition,
                    destination,
                    jumpTime
                )
            );

            if(jumpTime > 0.6) {
                animator.SetBool("IsMoving", false);
            }

            if(jumpTime >= 1f) {
                isMoving = false;
            }
        }
        playerLocation.Value = this.transform.position;
    }
}
