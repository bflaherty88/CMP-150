using UnityEngine;
using System.Collections;

public class Scorer : MonoBehaviour {

    public GameObject worldController;

    private WorldControl worldControl;

    void Start()
    {
        if (worldController == null)
            worldController = GameObject.FindGameObjectWithTag("GameController");
        worldControl = worldController.GetComponent<WorldControl>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            worldControl.score++;
            Destroy(this.gameObject);
        }
    }
}
