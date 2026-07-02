using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform firePoint;
    [SerializeField] float fireInterval = 3f;
    [SerializeField] float launchForce = 500f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, fireInterval);

    }

    // Update is called once per frame
    
    void Fire()
    {
        GameObject proj = Instantiate(projectilePrefab, firePoint.position, Quaternion.identity);
        Rigidbody rb = proj.GetComponent<Rigidbody>();
        rb.AddForce(firePoint.forward * launchForce);

    }
}
