using UnityEngine;
using System.Collections;

public class CamerControl : MonoBehaviour {

    private GameObject player;

    public float keyhole = 5f;

    public float moveSpeed = 10f;

    private Vector3 playerPos
    {
        get { return player.transform.position; }
    }

    private Vector3 cameraPos
    {
        get { return transform.position; }
    }

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player");

        if (playerPos.x > cameraPos.x - keyhole)
            transform.Translate(Vector3.right * (playerPos.x + keyhole - cameraPos.x) * moveSpeed * Time.deltaTime);
	}
}
