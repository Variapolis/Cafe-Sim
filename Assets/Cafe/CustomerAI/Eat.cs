using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Cafe.CookingSystem;
using UnityEngine;
using TheKiwiCoder;

[System.Serializable]
public class Eat : ActionNode
{
    private float _startTime;
    private Animator _animator;
    private const float eatTime = 7f;

    protected override void OnStart()
    {
        _startTime = Time.time;
        _animator = context.gameObject.GetComponentInChildren<Animator>();
        var layer = _animator.GetLayerIndex("Eating");
        _animator.SetTrigger("Eat");
        _animator.SetLayerWeight(layer, 1);
        ScoreOrder();
    }

    protected override void OnStop()
    {
    }

    protected override State OnUpdate()
    {
        if (Time.time - _startTime < eatTime) return State.Running;
        Stand();
        Object.Destroy(blackboard.Table.FoodTray.gameObject);
        return State.Success;
    }

    private void ScoreOrder()
    {
        if (blackboard.Table.FoodTray.FoodItems.Count != blackboard.Order.Count)
        {
            blackboard.Restaurant.Complain("My order was incorrect!", blackboard.Order.Count);
            return;
        }
        foreach (var t in blackboard.Order)
            if (blackboard.Table.FoodTray.FoodItems.All(f => f.IngredientName != t.Ingredient.IngredientName))
            {
                blackboard.Restaurant.Complain("My order was incorrect!", blackboard.Order.Count);
                return;
            }
        blackboard.Restaurant.Praise(blackboard.Order.Count);
    }

    private void Stand()
    {
        var layer = _animator.GetLayerIndex("Eating");
        _animator.SetLayerWeight(layer, 0);
        context.physics.isKinematic = false;
        context.physics.detectCollisions = true;
        context.agent.enabled = true;
        blackboard.Table.IsOccupied = false;
        context.gameObject.GetComponentInChildren<Animator>().SetTrigger("Stand");
        context.transform.position = blackboard.Chair.WalkToPosition;
    }
}