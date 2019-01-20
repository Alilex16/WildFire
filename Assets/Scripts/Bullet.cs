using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed;

    public bool bulletBounce;

    private int zigZagModifier = 12; // base, need testing
    private int zigZagTurnModifier;

    private float zigZagTimer;
    private float zigZagTimerMax;

    private void Start()
    {
        zigZagTimerMax = LevelModifiers.zigZagCurrent;

        // if (modifier is active){}
        //Invoke("BulletExplode", 0.5f);

    }

    private void FixedUpdate()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
        
        //ActualBounce(); // TESTING!!!
        
        //sliderRight.transform.Translate(0, -Time.deltaTime * speedRight, 0, Space.World);

        //transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * bulletSpeed);

        // ORIGINAL WORKING // transform.position += transform.up * bulletSpeed * Time.deltaTime; // instead of += // instead of bulletDirection

        if (LevelModifiers.ZigZagMod == true)
        {
            //zigZagModifier = GetComponent<LevelModifiers>().zigZagCurrent;
            
            zigZagTurnModifier = Random.Range(-zigZagModifier, zigZagModifier);

            zigZagTimer += Time.deltaTime;

            if (zigZagTimer > zigZagTimerMax)
            {
                transform.Rotate(0, 0, zigZagTurnModifier);
                zigZagTimer = 0;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Instantiate(explosionPrefab);

        // if (bulletBounceMod == true), bounce once
        if (LevelModifiers.bulletBounceMod == true)
        {
            if (bulletBounce == false)
            {
                //BulletBounce();
                ActualBounce();
                bulletBounce = true;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void BulletBounce()
    {
        //float a = transform.rotation.z;
        //float b = 360 / a ;//a * 360;

        float randomSpin = Random.Range(-180, 180);

        transform.Rotate(0, 0, randomSpin);
    }


    public float maxRayDistance = 15;
    
    private void ActualBounce()
    {
        Debug.DrawRay(transform.position, transform.up * 50, Color.gray);
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity);
        if (hit != null && hit.collider != null)
        {
            Vector3 inDirection = Vector3.Reflect(transform.up, hit.normal);

            Debug.DrawRay(hit.point, inDirection * 100, Color.red);
            hit = Physics2D.Raycast(hit.point + hit.normal * 0.01f, inDirection, Mathf.Infinity);
            if (hit != null && hit.collider != null)
            {
                inDirection = Vector3.Reflect(inDirection, hit.normal);
                Debug.DrawRay(hit.point, inDirection * 100, Color.green);

                //transform.Rotate(inDirection);
                Debug.Log(inDirection);

                //BulletBounce();

            }
        }
        

    }
    
    private void ActualBounceTest()
    {
        Ray2D ray = new Ray2D(transform.position, Vector2.up);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, Mathf.Infinity);

        Vector2 inDrection = Vector2.Reflect(transform.up, hit.normal);
        

        Debug.DrawLine(transform.position, transform.up * maxRayDistance, Color.red);

        if (Physics2D.Raycast (ray.origin, inDrection, maxRayDistance)) // ray.direction instead of inDrection
        {
            Debug.Log("LA");
        }

        //if (Physics.Raycast(ray, out hit, maxRayDistance))
        //{
        //    Debug.DrawLine(hit.point, hit.transform.up * 5, Color.green);
            //Debug.Log("You hit a ray.");
        //}
    }

}
