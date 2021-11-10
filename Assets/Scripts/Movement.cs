using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] SharedVector3 playerLocation;
    [SerializeField] GameObject ghost;
    [SerializeField] Animator animator;

    [SerializeField] EventSubscribe onFallEvent;
    Rigidbody rigidBody;

    private bool forcedMove = false;
    private float forcedMoveTime = 0f;
    private float forcedMoveDestTime = 1f;
    private bool isMoving = false;
    private bool isInjured = false;
    private Vector3 destination;
    private Vector3 jumpPosition;
    private float jumpTime = 0f;

    private bool canMove = true;
    void Start()
    {
        destination = Vector3.zero;
        rigidBody = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        playerLocation.Value = this.transform.position;
    }

    private void OnEnable() {
        onFallEvent.Callback += OnFall;
    }

    private void OnDisable() {
        onFallEvent.Callback -= OnFall;        
    }

    private void OnFall()
    {
        animator.Play("Fall");
        animator.SetBool("IsFalling", true);
        animator.SetBool("IsMoving", false);
        animator.SetBool("IsInjured", false);
        isMoving = false;
        isInjured = false;
        canMove = false;

    }

    private void OnFallDone()
    {
        animator.SetBool("IsFalling", false);
        jumpPosition = this.transform.position;
        destination -= (Vector3.up * 9);
        forcedMove = true;
        forcedMoveTime = 0f;
        forcedMoveDestTime = 0.5f;
        isMoving = false;
        canMove = true;
        isInjured = false;
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

    private void Move(Vector3 position)
    {
        rigidBody.MovePosition(position);
        if(ghost) {
            this.ghost.transform.position = new Vector3(
                0f,
                position.y,
                0f
            );
        }
    }
    void Update()
    {
        if(forcedMove) {
            forcedMoveTime += Time.deltaTime;
            Move(
                Vector3.Lerp(
                    jumpPosition,
                    destination,
                    forcedMoveTime / forcedMoveDestTime
                )
            );   

            if(forcedMoveTime >= forcedMoveDestTime) {
                forcedMove = false;
                forcedMoveTime = 0f;
            }
        }

        if(canMove && !isMoving && Input.GetKey(KeyCode.UpArrow)) {
            animator.SetBool("IsMoving", true);
            isMoving = true;
            jumpTime = 0f;

            jumpPosition = this.transform.position;
            destination = this.transform.position + (Vector3.up * 3);
            destination.x = 0f;
        } 

        if(canMove && !isMoving && Input.GetKey(KeyCode.LeftArrow)) {
            animator.SetBool("IsMoving", true);
            isMoving = true;
            jumpTime = 0f;

            jumpPosition = this.transform.position;
            destination = this.transform.position + (Vector3.up * 3);
            destination.x = -6f;
        }         

        if(canMove && !isMoving && Input.GetKey(KeyCode.RightArrow)) {
            animator.SetBool("IsMoving", true);
            isMoving = true;
            jumpTime = 0f;

            jumpPosition = this.transform.position;
            destination = this.transform.position + (Vector3.up * 3);
            destination.x = 6f;
        }         

        if(canMove && isMoving) {
            jumpTime += Time.deltaTime * 5;
            Move(
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
