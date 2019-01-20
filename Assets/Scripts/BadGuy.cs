using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BadGuy : MonoBehaviour {

    [Header("Bullet Prefab")]
    public GameObject Bullet; //

    [Header("Shows bullet trajectory in Scene")]
    public bool gismoOn;

    [Header("Stats")]
    public bool isBoss;
    public float fireRate;
    public int delayStartTimer = -5; // it starts with a slight delay // private set, public get
    private float bulletTimer;
    public int rotateDirectionZ;

    [Header("Ignore This")]
    public Transform PlaygroundPlaceholder; // use code instead of this shortcut
    
    void Start ()
    {
        bulletTimer = delayStartTimer;
        CalculateFireRate();
    }

    private void CalculateFireRate()
    {
        fireRate = 2; // fires a bullet every X seconds, fastests should be 0.5 ?
    }
    
    void FixedUpdate ()
    {
        bulletTimer += Time.deltaTime;
        
        if (bulletTimer >= fireRate)
        {
            DetermineRotationAngle();
            
            FireBullet();

            if (LevelModifiers.dualWieldMod == true)
            {
                Invoke("FireBullet", 0.25f);
            }
            
            bulletTimer = 0;
        }
	}
    
    private void FireBullet()
    {
        GameObject bulletCopy = Instantiate(Bullet, transform.position, transform.rotation);
        bulletCopy.SetActive(true);
        bulletCopy.transform.SetParent(PlaygroundPlaceholder);
    }

    public void DetermineRotationAngle()
    {
        rotateDirectionZ = Random.Range(-90, 90); // ORIGINAL WORKING 360 DEGREES: var directionZ = Random.Range(0, 360); // make this a variable
        
        if (isBoss)
        {
            rotateDirectionZ = Random.Range(-180, 180);
        }
        else
        {
            if (LevelModifiers.rotationAngleRound01 == true)
            {
                rotateDirectionZ = Random.Range(-120, 120);
            }
            if (LevelModifiers.rotationAngleRound02 == true)
            {
                rotateDirectionZ = Random.Range(-150, 150);
            }
            if (LevelModifiers.rotationAngleRound03 == true)
            {
                rotateDirectionZ = Random.Range(-180, 180);
            }
        }
        
        transform.Rotate(0, 0, rotateDirectionZ); // rotate the Z axis of the BadGuy to change aim
    }

    private void OnDrawGizmos()
    {
        int laserLength = 150;

        if (gismoOn)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawRay(transform.position, transform.up * laserLength); // TargetPosition * 100);
        }
    }
}
