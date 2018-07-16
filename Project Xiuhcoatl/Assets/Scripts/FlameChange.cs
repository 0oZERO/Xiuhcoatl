using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlameChange : MonoBehaviour
{

    public GameObject redFire;
    public GameObject blueFire;
    public GameObject whiteFire;
    public GameObject blackFire;
    public GameObject orangeFire;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedArea"))
        {
            redFire.SetActive(true);
            blueFire.SetActive(false);
            whiteFire.SetActive(false);
            blackFire.SetActive(false);
            orangeFire.SetActive(false);
        }
        if (other.CompareTag("BlueArea"))
        {
            redFire.SetActive(false);
            blueFire.SetActive(true);
            whiteFire.SetActive(false);
            blackFire.SetActive(false);
            orangeFire.SetActive(false);
        }
        if (other.CompareTag("WhiteArea"))
        {
            redFire.SetActive(false);
            blueFire.SetActive(false);
            whiteFire.SetActive(true);
            blackFire.SetActive(false);
            orangeFire.SetActive(false);
        }
        if (other.CompareTag("BlackArea"))
        {
            redFire.SetActive(false);
            blueFire.SetActive(false);
            whiteFire.SetActive(false);
            blackFire.SetActive(true);
            orangeFire.SetActive(false);
        }
        if (other.CompareTag("OrangeArea"))
        {
            redFire.SetActive(false);
            blueFire.SetActive(false);
            whiteFire.SetActive(false);
            blackFire.SetActive(false);
            orangeFire.SetActive(true);
        }
    }
}
