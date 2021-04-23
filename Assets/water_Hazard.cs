using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class water_Hazard : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerManager>().DeathState();

        }
    }
}
