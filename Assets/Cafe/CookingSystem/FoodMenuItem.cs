using UnityEngine;

namespace Cafe.CookingSystem
{
    [CreateAssetMenu]
    public sealed class FoodMenuItem : ScriptableObject
    {
        [SerializeField] private string name;
        [SerializeField] private Color color;
        public string Name => $"<color=#{ColorUtility.ToHtmlStringRGB(color)}>{name}</color>";
        public string PlainTextName => name;
        public Color Color => color;
        public Ingredient[] Ingredients;
    }
}