using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutSceneHandler : MonoBehaviour
{
    

    private System.Action onFinishedCallback;
    public void SetOnFinished(System.Action onFinishedCallback) {
        this.onFinishedCallback = onFinishedCallback;
        Debug.Log("omg");
    }


}
