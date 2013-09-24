using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class GoomboxAI : MonoBehaviour {

    public GameObject worldController;
    public float moveSpeed = 1f;
    public float gravity = 5f;

    private WorldControl worldControl;
    private CharacterController controller;
    private Vector3 origin;

	void Start () 
    {
        worldControl = worldController.GetComponent<WorldControl>();
        controller = this.GetComponent<CharacterController>();
        origin = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (worldControl.Respawning)
        {
            Respawn();
            Debug.Log("Resetting Goombox");
        }
        controller.Move(new Vector3(-moveSpeed, -gravity, 0));

	}

    public void Respawn()
    {
        transform.position = origin;
    }
}
