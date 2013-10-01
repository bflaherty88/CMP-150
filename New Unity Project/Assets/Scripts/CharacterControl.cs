using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(AudioSource))]
public class CharacterControl : MonoBehaviour
{
    CharacterController controller;

    public float moveSpeed = 5f;
    public float jumpHeight = 8f;
    public float jumpBoost = 1.5f;
    public float gravity = 20f;
    public int blinkTime = 3;

    private Vector3 moveDirection = Vector3.zero;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            moveDirection = transform.TransformDirection(moveDirection);
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpHeight;
                moveDirection.x *= jumpBoost;
                audio.Play();
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }

    public void Blink()
    {
        StartCoroutine(Blinker());
    }

    IEnumerator Blinker()
    {
        for (int i = 0; i < (4 * blinkTime); i++)
        {
            this.gameObject.renderer.enabled = false;
            yield return new WaitForSeconds(0.125f);
            this.gameObject.renderer.enabled = true;
            yield return new WaitForSeconds(0.125f);
        }
        yield return null;
     
    }

}
