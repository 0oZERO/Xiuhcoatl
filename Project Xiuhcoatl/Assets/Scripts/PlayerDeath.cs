using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class PlayerDeath : MonoBehaviour {

    bool colCheck = false;
    private void Update()
    {
                    Debug.Log(colCheck);
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Trap"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            colCheck = true;

        }
    }
}
