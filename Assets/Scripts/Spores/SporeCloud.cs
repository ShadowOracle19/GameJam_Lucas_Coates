using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SporeCloud : MonoBehaviour
{
    public Spores sporeProduced;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            if (!other.gameObject.GetComponent<PlayerManager>().ContainsSpore(sporeProduced))
            {
                other.gameObject.GetComponent<AudioSource>().Play();
            }
            other.gameObject.GetComponent<PlayerManager>().currentSpore = sporeProduced;
            
        }
    }
}
