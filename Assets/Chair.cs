﻿using UnityEngine;

public class Chair : MonoBehaviour
{
    [SerializeField] private Vector3 walkToPosition;
    [SerializeField] private Vector3 sitPosition;

    public Vector3 WalkToPosition => transform.position + walkToPosition;
    public Vector3 SitPosition => transform.position + sitPosition;
    
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(WalkToPosition + Vector3.up * 0.01f, WalkToPosition - Vector3.up * 0.01f);
        Gizmos.DrawLine(WalkToPosition + Vector3.left * 0.01f, WalkToPosition - Vector3.left * 0.01f);
        Gizmos.DrawLine(WalkToPosition + Vector3.forward * 0.01f, WalkToPosition - Vector3.forward * 0.01f);
        
        Gizmos.color = Color.cyan;
        Gizmos.DrawLine(SitPosition + Vector3.up * 0.01f, SitPosition - Vector3.up * 0.01f);
        Gizmos.DrawLine(SitPosition + Vector3.left * 0.01f, SitPosition - Vector3.left * 0.01f);
        Gizmos.DrawLine(SitPosition + Vector3.forward * 0.01f, SitPosition - Vector3.forward * 0.01f);
    }
}