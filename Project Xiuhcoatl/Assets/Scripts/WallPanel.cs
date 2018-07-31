using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPanel : MonoBehaviour {

    public GameObject trigger;
    public GameObject projectile;
    public GameObject target;
    public float panelSpeed;
    public float spawnerDelay;
    public float spawnerSpeed;
    public float shootInterval;
    public float unchild;

    private GameObject spawner;
    private GameObject panel;
    private Vector3 spawnerPosition;
    private Vector3 endPosition;
    private bool active;

    void Start ()
    {
        spawner = transform.Find("Spawner").gameObject;
        panel = transform.Find("WallPanel").gameObject;
        spawnerPosition = transform.Find("SpawnerPosition").localPosition;
        endPosition = new Vector3(0, 0, 0);
        spawner.GetComponent<Spawner>().trigger = trigger;
        spawner.GetComponent<Spawner>().projectile = projectile;
        spawner.GetComponent<Spawner>().target = target;
        spawner.GetComponent<Spawner>().spawnerDelay = spawnerDelay;
        spawner.GetComponent<Spawner>().spawnerSpeed = panelSpeed;
        spawner.GetComponent<Spawner>().speed = spawnerSpeed;
        spawner.GetComponent<Spawner>().interval = shootInterval;
        spawner.GetComponent<Spawner>().unchild = unchild;
        active = false;
    }
	
	void Update ()
    {
        active = trigger.GetComponent<Activator>().active;
        spawner.GetComponent<Spawner>().endPosition = spawnerPosition;
        if (active)
        {
            panel.transform.localPosition = Vector3.Lerp(panel.transform.localPosition, endPosition, panelSpeed);
        }
	}
}
