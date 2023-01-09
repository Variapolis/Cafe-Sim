using UnityEngine;
using TheKiwiCoder;
using Unity.VisualScripting;

[System.Serializable]
public class MakeOrder : ActionNode
{
    private SpeechBubbleController _speechBubbleController;
    protected override void OnStart()
    {
        var menu = blackboard.Restaurant.FoodMenu.items;
        for (int i = 1; i <= Random.Range(1,5); i++) blackboard.Order.Add(menu[Random.Range(0, menu.Length)]);
        Debug.Log(blackboard.Order.ToArray().ToCommaSeparatedString());
        _speechBubbleController = context.gameObject.GetComponent<SpeechBubbleController>();
        _speechBubbleController.Order = blackboard.Order;
        _speechBubbleController.Enable();
    }

    protected override void OnStop()
    {
        _speechBubbleController.enabled = false;
        blackboard.QueuePoint.IsOccupied = false;
    }

    protected override State OnUpdate() => _speechBubbleController.IsFinished ? State.Success : State.Running;
}
