using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

    private bool respawning = false;
    private bool paused = false;

    public GameObject player;
    private Vector3 playerStart;
    public GameObject camera;
    private Vector3 cameraStart;

    public float keyhole = 5f;
    public float cameraSpeed = 10f;

    public GUIStyle menuStyle;
    public float floor = -10f;

    private Vector3 playerPos
    {
        get { return player.transform.position; }
    }

    private Vector3 cameraPos
    {
        get { return camera.transform.position; }
    }
	
    void Start()
    {
        playerStart = playerPos;
        cameraStart = cameraPos;
    }

	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();

        if (playerPos.x > cameraPos.x - keyhole && !respawning)
            camera.transform.Translate(Vector3.right * (playerPos.x + keyhole - cameraPos.x) * cameraSpeed * Time.deltaTime);

        if (player.transform.position.y < floor)
            Respawn();
	}

    void PauseGame()
    {
        if (paused)
        {
            Time.timeScale = 1f;
            paused = false;
        }
        else
        {
            Time.timeScale = 0f;
            paused = true;
        }
    }

    void OnGUI()
    {
        if (paused)
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Paused", menuStyle);
        
    }

    public void Respawn()
    {
        respawning = true;
        GameObject temp = Instantiate(player, playerStart, Quaternion.identity) as GameObject;
        Destroy(player);
        camera.transform.position = cameraStart;
        player = temp;
        temp = null;
        CharacterControl characterControl = player.GetComponent<CharacterControl>();
        characterControl.Blink();
        characterControl = null;
        respawning = false;
    }
}
