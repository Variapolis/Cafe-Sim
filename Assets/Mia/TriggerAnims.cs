using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public sealed class TriggerAnims : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] private ScrollRect scrollRect;
    [SerializeField] private Button buttonPrefab;

    void Start()
    {
        foreach (var param in anim.parameters)
        {
            var button = Instantiate(buttonPrefab, scrollRect.content);
            button.GetComponentInChildren<TMP_Text>().text = $"Anim {param.name}";
            button.onClick.AddListener(() => anim.SetTrigger(param.name));
        }
    }
}