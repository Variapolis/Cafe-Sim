using JetBrains.Annotations;
using UnityEngine;

public interface IItemInteractable
{
    public bool InteractWithItem([NotNull] GameObject item);
}