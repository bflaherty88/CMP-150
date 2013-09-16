using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public Control MoveForward;
    public Control MoveBackward;
    public Control TurnLeft;
    public Control TurnRight;
    public Control Jump;

    public float moveSpeed = 5f;
    public float rotSpeed = 100f;
    public float jumpHeight = 5f;

    private bool isGrounded = false;

    private float trueSpeed
    {
        get { return (moveSpeed * Time.deltaTime); }
    }

    private float trueRotSpeed
    {
        get { return (rotSpeed * Time.deltaTime); }
    }

	
	void Start () {
	
	}
	
	
	void Update () {

        //Change to physics movement

        if (MoveForward.IsActive)
        {
            transform.Translate(Vector3.forward * trueSpeed);
        }
        if (MoveBackward.IsActive)
        {
            transform.Translate(Vector3.forward * -trueSpeed);
        }
        if (TurnLeft.IsActive)
        {
            transform.Rotate(Vector3.down * trueRotSpeed);
        }
        if (TurnRight.IsActive)
        {
            transform.Rotate(Vector3.down * -trueRotSpeed);
        }

        if (Jump.IsPressed && isGrounded)
        {
            rigidbody.AddForce(Vector3.up * jumpHeight);
        }
        
        //add terminal vel
	}

    void OnCollisionStay(Collision collisionInfo)
    {
        foreach (ContactPoint contact in collisionInfo.contacts)
        {
            if (transform.position.y - .75 > contact.point.y)
                isGrounded = true;
            else
                isGrounded = false;
        }
    }

    void OnCollisionExit()
    {
        isGrounded = false;
    }
}
