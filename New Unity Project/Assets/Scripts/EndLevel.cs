using UnityEngine;
using System.Collections;

public class EndLevel : MonoBehaviour {

    public GameObject wall;
    public ParticleSystem endParticle1, endParticle2;

    private bool hasWon = false;

    public bool HasWon
    {
        get { return hasWon; }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            hasWon = true;
            wall.SetActive(true);
            endParticle1.Play();
            endParticle2.Play();
            
        }
    }
}
