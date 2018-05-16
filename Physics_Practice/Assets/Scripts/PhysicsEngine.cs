using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[DisallowMultipleComponent]
public class PhysicsEngine : MonoBehaviour
{
    [SerializeField] float mass = 5; // in kg

    [SerializeField] Vector3 velocityVector; // m/s
    [SerializeField] Vector3 netForceVector; // N [kg m/s^2]

    [SerializeField] bool showTrails = true;
   

    private List<Vector3> forceVectorList = new List<Vector3>();
    private LineRenderer lineRenderer;
    private int numberOfForces;



    // Use this for initialization
    void Start ()
    {      
            SetupThrustTrails();     
    }

     void SetupThrustTrails()
    {
        lineRenderer = gameObject.AddComponent<LineRenderer>();
        lineRenderer.material = new Material(Shader.Find("Sprites/Default"));
        lineRenderer.startColor = Color.yellow;
        lineRenderer.endColor = Color.yellow;
        lineRenderer.startWidth = 0.2f;
        lineRenderer.endWidth = 0.2f;
        lineRenderer.useWorldSpace = false;
    }

     void RenderTrails()
    {
        if (showTrails)
        {
            lineRenderer.enabled = true;
            numberOfForces = forceVectorList.Count;
            lineRenderer.positionCount = numberOfForces * 2;
            int i = 0;
            foreach (Vector3 forceVector in forceVectorList)
            {
                lineRenderer.SetPosition(i, Vector3.zero);
                lineRenderer.SetPosition(i + 1, -forceVector);
                i = i + 2;
            }
        }
        else
        {
            lineRenderer.enabled = false;
        }
    }

    void FixedUpdate()
    {
        
        RenderTrails();
        UpdatePosition();

    }
    public void AddForce (Vector3 forceVector)
    {
        forceVectorList.Add(forceVector);
    }

    void UpdatePosition()
    {
        // sums the forces and cleas the list
        netForceVector = Vector3.zero;

        foreach (Vector3 forceVector in forceVectorList)
        {
            netForceVector = netForceVector + forceVector;
        }

        forceVectorList.Clear();// clear the list


        Vector3 accelerationVector = netForceVector / mass;
        velocityVector = velocityVector + accelerationVector * Time.deltaTime;
        transform.position = transform.position + velocityVector * Time.deltaTime;

    }



}

