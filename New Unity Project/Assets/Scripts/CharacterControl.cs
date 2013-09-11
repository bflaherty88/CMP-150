using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    public Control MoveForward;
    public Control MoveBackward;
    public Control MoveLeft;
    public Control MoveRight;
    public Control Jump;

    public float moveSpeed = 5f;
    public float jumpHeight = 5f;

    private float trueSpeed
    {
        get { return (moveSpeed * Time.deltaTime); }
    }

	
	void Start () {
	
	}
	
	
	void Update () {

        if (MoveForward.IsActive)
        {
            transform.Translate(Vector3.forward * trueSpeed);
        }
        if (MoveBackward.IsActive)
        {
            transform.Translate(Vector3.forward * -trueSpeed);
        }
        if (MoveLeft.IsActive)
        {
            transform.Translate(Vector3.left * trueSpeed);
        }
        if (MoveRight.IsActive)
        {
            transform.Translate(Vector3.left * -trueSpeed);
        }

        if (Jump.IsPressed) //Need Ground Check Here
        {
            rigidbody.AddForce(Vector3.up * jumpHeight);
        }
	}
}
