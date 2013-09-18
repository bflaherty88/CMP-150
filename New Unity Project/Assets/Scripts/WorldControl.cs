using UnityEngine;
using System.Collections;

public class WorldControl : MonoBehaviour {

    private bool paused = false;

    public GUIStyle menuStyle;
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            PauseGame();

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
}
