using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsernameInputHandler : MonoBehaviour
{
    [SerializeField] private UI_UsernameInput uiUsernameInput;
    private UsernameInput userInput;

    private System.Action onProcessedCallback;

    public void SetOnProcessed(System.Action onProcessedCallback) {
        this.onProcessedCallback = onProcessedCallback;
    }
    private void Start() {
        userInput = new UsernameInput(uiUsernameInput);

        uiUsernameInput.Setup(OnConfirmPressed);

        //Debug.Log("sdfldff");
    }

    private void OnConfirmPressed() {
        if (userInput.IsValid()) {
            UserVariables.username = userInput.GetInputString();
            onProcessedCallback?.Invoke();
        }
    }
}

public class UsernameInput {
    private IUsernameInput usernameInput;
    public UsernameInput(IUsernameInput usernameInput) {
        this.usernameInput = usernameInput;
    }

    public bool IsValid() {
        return usernameInput.GetInput().Length <= 10 && usernameInput.GetInput().Length >= 3;
    }

    public string GetInputString() {
        return usernameInput.GetInput();
    }
}