using System.Collections.Generic;
using Cafe.CookingSystem;
using UnityEngine;

namespace TheKiwiCoder {

    // This is the blackboard container shared between all nodes.
    // Use this to store temporary data that multiple nodes need read and write access to.
    // Add other properties here that make sense for your specific use case.
    [System.Serializable]
    public class Blackboard {

        public Vector3 moveToPosition;
        public Restaurant Restaurant;
        public Kiosk Kiosk;
        public QueuePoint QueuePoint;
        public Table Table;
        public Chair Chair;
        public readonly List<FoodMenuItem> Order = new();
        public float EatTime;
    }
}