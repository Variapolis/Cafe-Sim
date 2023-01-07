using UnityEngine;

namespace Cafe.CookingSystem
{
    [CreateAssetMenu]
    public sealed class FoodMenuItem : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Color color;
        public string Name => $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{_name}</color>";
        public string PlainTextName => _name;
        public Color Color => color;
        public FoodItem Ingredient;
    }
}