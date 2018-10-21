using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBehavior : MonoBehaviour {

    public float 
        height, 
        gravity, 
        radius;

    private float
        position,
        speed,
        acceleration,
        buoyancy,
        submergedHeight,
        submergedVolume;

    private bool
        isUnderWater;


	void Start () {
        position = height;
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

            // Calculate submerged sphere volume
            if (height >= 0)
            {
               // submergedVolume = ((Mathf.PI * Abs(position - radius) * Abs(position - radius))/3)*(3*radius - Abs(position - radius));
            }
        }

        UpdatePosition();
       Debug.Log(submergedHeight);

    }

    void UpdatePosition ()
    { 
        transform.position = new Vector3(0.0f, position, 0.0f);
    }

}
