using UnityEngine;
using UnityEngine.AI;

public class SyncWalkSpeed : MonoBehaviour
{
    [SerializeField] private NavMeshAgent navMeshAgent;
    [SerializeField] private Animator animator;
    
    void Update() => animator.SetFloat("WalkSpeed", navMeshAgent.velocity.magnitude);
}