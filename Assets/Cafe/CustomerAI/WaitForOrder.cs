using TheKiwiCoder;
using UnityEngine;

[System.Serializable]
public class WaitForOrder : ActionNode
{
    private bool _startedEating;
    private float _eatStartTime;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate()
    {
        if (!blackboard.Table.FoodTray) return State.Running;
        return Time.time - _eatStartTime > blackboard.EatTime ? State.Success : State.Running;
    }
    
}
