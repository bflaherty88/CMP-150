using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public GameObject worldController;

    private WorldControl worldControl;

    void Start()
    {
        if (worldController == null)
            worldController = GameObject.FindGameObjectWithTag("GameController");
        worldControl = worldController.GetComponent<WorldControl>();
    }

    void Update()
    {
        animation.Play();
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
