using UnityEngine;
using TheKiwiCoder;
using Random = UnityEngine.Random;

[System.Serializable]
public class Dice : ActionNode
{
    [SerializeField] private int chance;
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() => Random.Range(0, 100) < chance ? State.Success : State.Failure;
}
