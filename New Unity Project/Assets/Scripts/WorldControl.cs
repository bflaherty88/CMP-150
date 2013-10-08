using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

    private bool respawning = false;
    private bool paused = false;
    private bool hasWon = false;
    private bool gameOver = false;

    public GameObject player;
    public GameObject camera;
    public GameObject endTrigger;
    public static int score = 0;
    public int lives = 5;

    private Vector3 playerStart;
    private Vector3 cameraStart;
    private EndLevel endLevel;
    CharacterControl characterControl;

    public float keyhole = 5f;
    public float cameraSpeed = 10f;

    public GUIStyle menuStyle;
    public GUIStyle scoreStyle;
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
        if (player == null)
        {
            player = GameObject.FindWithTag("Player");
        }

        if (camera == null)
        {
            camera = GameObject.FindWithTag("MainCamera");
        }

        if (endTrigger == null)
        {
            endTrigger = GameObject.FindWithTag("Finish");
        }

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
                Kill();
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
        if (endLevel.HasWon)
        {
            if ((int)Time.time % 2 == 1)
            {
                GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "WIENER!", menuStyle);
            }
        }
        else if (paused)
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Paused", menuStyle);
        else if (gameOver)
            GUI.Label(new Rect(0, 0, Screen.width, Screen.height), "Game Over", menuStyle);

        GUI.Label(new Rect(0f, Screen.height - 40, 50f, 40f), "Score: " + score + "\nLives: " + lives, scoreStyle);
        
    }

    public void Kill()
    {
        if (lives > 0)
        {
            respawning = true;
            GameObject temp = Instantiate(player, playerStart, Quaternion.identity) as GameObject;
            Destroy(player);
            camera.transform.position = cameraStart;
            player = temp;
            temp = null;
            CharacterControl characterControl = player.GetComponent<CharacterControl>();
            characterControl.Blink();
            if (score > 0)
                score /= 2;
            lives--;
            respawning = false;
        }
        else
            GameOver();
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver = true;

    }

    public void FinishLevel()
    {

    }
}
