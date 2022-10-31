using TMPro;
using UnityEngine;

namespace Mia
{
    public class KioskDemo : MonoBehaviour
    {
        [SerializeField] private GameObject BasketItemPrefab;
        [SerializeField] private GameObject MenuContent;
        [SerializeField] private GameObject BasketContent;

        void Start()
        {
            foreach (var button in MenuContent.GetComponentsInChildren<KioskButton>())
                button.Button.onClick.AddListener(() => Instantiate(BasketItemPrefab, BasketContent.transform).GetComponent<TMP_Text>().text = $" - {button.Name}\n    $5.99");
        }
    }
}