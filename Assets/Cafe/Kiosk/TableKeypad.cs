using TMPro;
using UnityEngine;

public class TableKeypad : MonoBehaviour
{
    [SerializeField] private TMP_Text textField;

    public void AddNumber(string number) => textField.text += number;
    public void DeleteNumber() => textField.text = textField.text.Remove(textField.text.Length - 1);
}
