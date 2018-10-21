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
        SubmergedSphereVolume;

    private bool
        isUnderWater;


	void Start () {
        
        position = height;
        UpdatePosition();
    }
	
	void Update () {
        //Check is spehere touches the water
        //Calculate sphere volume if it does
        //SubmergedSphereVolume = 

        UpdatePosition();
       // Debug.Log(Time.deltaTime);

    }

    void UpdatePosition ()
    { 
        transform.position = new Vector3(0.0f, position, 0.0f);
    }

}
