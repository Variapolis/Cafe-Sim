using System;
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    [SerializeField] private Transform waypoint;

    private void Start() => navMeshAgent.destination = waypoint.position;

    void Update() => animator.SetFloat("WalkSpeed", navMeshAgent.velocity.magnitude);
}
