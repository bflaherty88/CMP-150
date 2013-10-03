using UnityEngine;
using System.Collections;

public class Coin : MonoBehaviour {

    public AudioClip pickup;
    public int value = 1;

    void Update()
    {
        animation.Play();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("Player"))
        {
            WorldControl.score += value;
            AudioSource.PlayClipAtPoint(pickup, transform.position);
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
    }
}
