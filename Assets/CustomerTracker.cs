using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerTracker : MonoBehaviour
{
    public static int Total { get; private set; }

    void Start() => Total++;

    void OnDestroy() => Total--;
}
