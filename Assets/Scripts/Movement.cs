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
    private bool isInjured = false;
    private Vector3 destination;
    private Vector3 jumpPosition;
    private float jumpTime = 0f;

    void Start()
    {
        destination = Vector3.zero;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }


    private void OnCollisionEnter(Collision other) {
        if ( other.gameObject.tag == "Enemey" ) {
            Debug.Log("OnCollisionEnter");
        }    
    }
    private void OnTriggerEnter(Collider other) {

        if (!isInjured && other.tag == "Enemy" ) {
            Debug.Log("OnTriggerEnter");
           //targetPosition = originalPosition;
            //Debug.Log("OnTriggerEnter");
            destination -= (Vector3.up * 9);
            isMoving = true;
            isInjured = true;
            jumpTime = Mathf.Clamp(1f - jumpTime, 0f, 0.9f);
            animator.SetBool("IsInjured", true);
        }
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
                animator.SetBool("IsInjured", false);
                isMoving = false;
                isInjured = false;
            }
        }
        playerLocation.Value = this.transform.position;
    }
}
