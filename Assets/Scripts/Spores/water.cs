using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water : MonoBehaviour
{
    BoxCollider boxCollider;
    public bool allowedToEnter;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Player")
        {
            PlayerManager player = other.gameObject.GetComponent<PlayerManager>();
            if (!player.ContainsSpore(Spores.Water))
            {
                //the player has water spore
                boxCollider.enabled = false;
            }
            


        }
    }
    
}
