using UnityEngine;

namespace Cafe.CookingSystem
{
    [CreateAssetMenu]
    public sealed class FoodMenuItem : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Color _nameColor;
        public string Name => $"<color=#{ColorUtility.ToHtmlStringRGB(_nameColor)}>{_name}</color>";
        public Ingredient[] Ingredients;
    }
}