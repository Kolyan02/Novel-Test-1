using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_UsernameInput : MonoBehaviour, IUsernameInput
{
    [SerializeField] private InputField inputField;
    private System.Action onConfirmPressed;

    public void Setup(System.Action onConfirmPressed) {
        this.onConfirmPressed = onConfirmPressed;
    }
    public void PressConfirm() {
        onConfirmPressed?.Invoke();
    }

    public string GetInput() {
        return inputField.text;
    }

}
