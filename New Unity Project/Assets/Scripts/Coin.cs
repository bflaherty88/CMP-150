using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public GameObject worldController;
    public AudioClip pickup;
    public int value = 1;

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
            worldControl.score += value;
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
    }
}
