using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathCheck : MonoBehaviour {
    public Texture[] textures;
    
    //accepts a value from other scripts attached to a hazard
    [HideInInspector]
    public int deathInput;
    [HideInInspector]
    public Texture displayTexture; 
	// Update is called once per frame
	void Update () {

        //Depending on what input they get externally from the hazards, depends on what happends on death. 
        //This will allow up to do unique stuff for each death like play different particle effects or play a unique sound effect on the appropriate death. 
        //Ex. crunching sound and bloody floor play/spawn when squashed by a wall and text fading in, "Crushed to Death".  
        switch (deathInput)
        {
            case 0:
                Debug.Log("Player is alive");
                break;

            case 1:
                Debug.Log("Died by Arrow");
                displayTexture = textures[0];
                break;

            case 2:
                Debug.Log("Died by Boulder");
                break;

            case 3:
                Debug.Log("Died by Walls");
                break;

            case 4:
                Debug.Log("Died by Ceiling");
                break;

            case 5:
                Debug.Log("Died by Falling");
                displayTexture = textures[1];
                break;

        }
        
	}
}
