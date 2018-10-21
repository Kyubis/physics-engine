using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour {

    public float 
        height, 
        gravity, 
        sphereRadius;

    private float 
        position, 
        speed, 
        acceleration, 
        buoyancy, 
        SubmergedVolume;

    private bool
        isUnderWater;


	void Start () {
        position = height;
        UpdatePosition();
        // Update sphere scale to represent its actual size. 
        transform.localScale = new Vector3(sphereRadius*2, sphereRadius*2, sphereRadius*2);
    }
	
	void Update () {
        //Check is spehere touches the water
        if (position - sphereRadius < 0)
        {
            isUnderWater = true;
        }
        else
        {
            isUnderWater = false;
        }

        //Buoyancy calculation
        //Calculate sphere volume
        //SubmergedVolume = 

       UpdatePosition();
       Debug.Log(isUnderWater);

    }

    void UpdatePosition ()
    { 
        transform.position = new Vector3(0.0f, position, 0.0f);
    }

}
