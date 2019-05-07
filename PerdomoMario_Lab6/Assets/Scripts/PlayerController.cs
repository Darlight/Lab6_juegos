using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{
    //Needs a camera to get the input position from the mouse
    public Camera pointer;
    //An agent component to get the destination functions
    public NavMeshAgent agent;
    #region
    public static PlayerController instance;
    void Awake()
    {
        instance = this;
    }
    #endregion
    public GameObject player;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {   
            //Creates a raycaster that gives back a position within the camera
            Ray ray = pointer.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            //If the raycast hits withing the camera, it moves the object.
            if (Physics.Raycast(ray, out hit))
            {
                //Moves the agent to where the mouse was clicked.
                agent.SetDestination(hit.point); 
            }
        }

    }
    private void OnCollisionEnter(Collision col)
    {
        // Detects the enemy and gets destroyed.
        if (col.gameObject.name == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }
}
