using System;
using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

[RequireComponent(typeof(Button))]
public class KioskButton : MonoBehaviour
{
    public string Name;
    public Button Button;
    [SerializeField] private TMP_Text text;

    private void Reset()
    {
        Button = GetComponent<Button>();
        text = GetComponentInChildren<TMP_Text>();
    }

    private void Awake() => text.text = Name;
}