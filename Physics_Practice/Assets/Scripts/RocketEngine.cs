using UnityEngine;
using System.Collections;
using System.Collections.Generic;

 [RequireComponent (typeof(PhysicsEngine))]

public class RocketEngine : MonoBehaviour {

    [SerializeField] float fuelMass; // kg
    [SerializeField] float maxThrust;  // kN (kiloNewtons)[kg m/s^2]
    [SerializeField] float thrustPercent;  // no units
    [SerializeField] Vector3 thrustUnitVector; // no units

    PhysicsEngine physicsEngine;
    
	// Use this for initialization
	void Start ()
    {
        physicsEngine = GetComponent<PhysicsEngine>();     
	}
	
	// Update is called once per frame
	void FixedUpdate ()
    {

        physicsEngine.AddForce(thrustUnitVector);

	}
}
 