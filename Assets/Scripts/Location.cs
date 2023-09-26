using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Location
{
    public CutSceneHandler cutSceneHandler;
    public GameObject GO;

    public void Show(System.Action onFinishedCallback) {
        GO.SetActive(true);
        cutSceneHandler.SetOnFinished(onFinishedCallback);
    }

    public void Hide() {

    }
}
