using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

    private bool respawning = false;
    private bool paused = false;
    private bool hasWon = false;

    public GameObject player;
    public GameObject camera;
    public GameObject endTrigger;

    private Vector3 playerStart;
    private Vector3 cameraStart;
    private EndLevel endLevel;
    CharacterControl characterControl;

    public float keyhole = 5f;
    public float cameraSpeed = 10f;

    public GUIStyle menuStyle;
    public float floor = -10f;

    public Vector3 playerPos
    {
        get { return player.transform.position; }
    }

    public Vector3 cameraPos
    {
        get { return camera.transform.position; }
    }

    public Vector3 endPos
    {
        get { return endTrigger.transform.position; }
    }

    public bool Respawning
    {
        get { return respawning; }
    }
	
    void Start()
    {
        playerStart = playerPos;
        cameraStart = cameraPos;
        endLevel = endTrigger.GetComponent<EndLevel>();
        characterControl = player.GetComponent<CharacterControl>();
    }

	void Update () 
    {

        if (!endLevel.HasWon)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                PauseGame();

            if (playerPos.x > cameraPos.x - keyhole && !respawning)
                camera.transform.Translate(Vector3.right * (playerPos.x + keyhole - cameraPos.x) * cameraSpeed * Time.deltaTime);

            if (player.transform.position.y < floor)
                Respawn();
        }
        else
        {
            camera.transform.Translate(Vector3.right * (endPos.x - cameraPos.x) * cameraSpeed * Time.deltaTime);
        }

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
       // respawning = false;
    }

    public void FinishLevel()
    {

    }
}
