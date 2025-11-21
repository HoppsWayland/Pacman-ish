using System;
using UnityEngine;
using UnityEngine.AI; // IMPORTANT: Need this for NavMeshAgent

public class GhostAI : MonoBehaviour
{
    // The NavMeshAgent component on the ghost
    private NavMeshAgent agent; 
    
    public Transform target;
    private Vector3 currentDir;
    public float speed=4;

    void Start()
    { 
        agent = GetComponent<NavMeshAgent>(); 
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
       agent.SetDestination(target.position);
    }
}