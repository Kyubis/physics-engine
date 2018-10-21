using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour {

    public float
        height,
        gravity,
        radius,
        mass,
        fluidDensity;

    private float
        position,
        speed,
        acceleration,
        force,
        buoyancy,
        submergedHeight,
        submergedVolume,
        submergedCut;

    private bool
        isUnderWater;


	void Start () {
        position = height;
        speed = 0;
        acceleration = 0;
        force = mass * gravity;
        UpdatePosition();
        // Update sphere scale to represent its actual size. 
        transform.localScale = new Vector3(radius*2, radius*2, radius*2);
    }

    void Update() {
        //Check if spehere touches the water
        if (position - radius < 0)
        {
            isUnderWater = true;
        }
        else
        {
            isUnderWater = false;
        }

        //Buoyancy calculation
        if (isUnderWater)
        {
            // Calculate submerged sphere height
            // If sphere is fully submerged
            if (height < (radius*-1))
            {
                submergedHeight = radius * 2;
            }
            //If sphere is pattially submerged
            else
            {
                submergedHeight = Mathf.Abs(position - radius);
            }

            //Calculate water circle cut radius
            if ((submergedHeight * ((2 * radius) - submergedHeight) >= 0))
            {
                submergedCut = Mathf.Sqrt(submergedHeight * ((2 * radius) - submergedHeight));
            }


            // Calculate submerged sphere volume
            if (submergedHeight >= 0)
            {
                submergedVolume = (Mathf.PI / 6) * submergedHeight * ((3 * submergedCut * submergedCut) + (submergedHeight * submergedHeight));
            }

            buoyancy = submergedVolume * fluidDensity * gravity;
        }
        else {
            buoyancy = 0;
        }


        acceleration = ((buoyancy - force)/mass)*0.001f; //Slowing it down as it is very fast, misscalculated something somewhere
        speed = speed + acceleration;
        position = position + speed;

        UpdatePosition();

    }

    void UpdatePosition ()
    { 
        transform.position = new Vector3(0.0f, position, 0.0f);
    }

}
