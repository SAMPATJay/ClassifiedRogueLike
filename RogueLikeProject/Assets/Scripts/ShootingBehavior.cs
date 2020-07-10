using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingBehavior : MonoBehaviour
{
    [SerializeField] private bool hasRecoil;
    [SerializeField] private float recoilForce;
    [SerializeField] private float projectileSpeed;
    [SerializeField] private float rateOfFire;
    float timeToFire;
    bool isShooting;

    [SerializeField] private GameObject projectile;
    [SerializeField] private Rigidbody2D recoilObject;


    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetAxisRaw("XShoot") != 0 || Input.GetAxisRaw("YShoot") != 0)
        {
            if (Time.time > timeToFire && !isShooting)
            {
                isShooting = true;
                timeToFire += 1 / rateOfFire;
                Fire();
            }
        }

        /*else if (automaticFiring)
        {
            if (Input.GetButton("Jump"))
            {
                if (Time.time > timeToFire)
                {
                    timeToFire += 1 / rateOfFire;
                    Fire();
                }
            }
        }*/
        
        
    }

    void Fire()
    {
        Debug.Log("Fired");

        GameObject instance = Instantiate(projectile, transform.position, Quaternion.identity);
        Vector2 direction = new Vector2(Input.GetAxisRaw("XShoot"), Input.GetAxisRaw("YShoot"));
        instance.GetComponent<Rigidbody2D>().velocity = direction*projectileSpeed;

        if (hasRecoil)
        {
            recoilObject.AddForce(-direction * recoilForce, ForceMode2D.Force);
        }
        isShooting = false;
    }
}
