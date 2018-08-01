using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject trigger;
    public GameObject projectile;
    public GameObject target;
    public float speed;
    public float interval;

    [HideInInspector]
    public GameObject projectileSpawn;
    public Vector3 endPosition;
    public float spawnerDelay = 0;
    public float spawnerSpeed;
    public float unchild = 0;
    public bool active;

    private float timer;
    private float time;
    private float shotInterval;
    private bool shotProjectile;
    private bool done;
    private bool prjectileTime;


    void Start()
    {
        projectileSpawn = transform.Find("ProjectileSpawn").gameObject;
        endPosition = transform.localPosition;
        timer = 0f;
        time = spawnerDelay + unchild;
        shotProjectile = false;
        done = false;
    }

    void Update()
    {
        active = trigger.GetComponent<Activator>().active;
        if (active)
        {
            timer += Time.deltaTime;
            if (timer > spawnerDelay && !done)
            {
                transform.localPosition = Vector3.Lerp(transform.localPosition, endPosition, spawnerSpeed);
                //transform.position = Vector3.Lerp(transform.position, endPosition, speed);
            }
            if (timer > time)
            {
                done = true;
            }
            if (done && timer < interval + shotInterval)
            {
                transform.parent = null;
                var targetRotation = Quaternion.LookRotation(target.transform.position - transform.localPosition);
                transform.localRotation = Quaternion.Slerp(transform.localRotation, targetRotation, speed * Time.deltaTime);
                //transform.LookAt(target.transform);
            }
            if (timer > interval && shotProjectile == false)
            {
                //Instantiate(projectile, projectileSpawn.transform.localPosition, transform.localRotation);
                var tempProjectile = Instantiate(projectile, projectileSpawn.transform.position, transform.rotation);
                tempProjectile.transform.parent = projectileSpawn.transform;
                shotInterval = projectile.GetComponent<Projectile>().interval;
                shotProjectile = true;
            } 
            /*if(timer > interval + shotInterval)
            {
                projectile.transform.parent = null;
            }*/
        }
    }
}
