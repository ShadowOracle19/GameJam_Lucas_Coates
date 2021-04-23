using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Rigidbody bulletPrefab;
    public Transform spawnPoint;
    public float bulletSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("Shoot", 0.1f, 0.3f);
        StartCoroutine(shooter());
    }

    public void Shoot()
    {
        
    }

    IEnumerator shooter()
    {
        while(true)
        {
            Rigidbody bullet = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
            bullet.velocity = -transform.up * bulletSpeed;
            yield return new WaitForSeconds(0.3f);
            Rigidbody bullet2 = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
            bullet2.velocity = -transform.up * bulletSpeed;
            yield return new WaitForSeconds(0.3f);
            Rigidbody bullet3 = Instantiate(bulletPrefab, spawnPoint.transform.position, Quaternion.identity);
            bullet3.velocity = -transform.up * bulletSpeed;
            yield return new WaitForSeconds(2.0f);
        }

    }
}
