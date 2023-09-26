using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{

    [Header("Enter username")]
    [SerializeField] private UsernameInputHandler usernameInputHandler;
    [SerializeField] private GameObject uiUsernameInputGO;

    [Space]
    [Header("Quests")]
    [SerializeField] private GameObject questPanelGO;
    [SerializeField] private List<Quest> quests;

    [Space]
    [Header("Locations")]
    [SerializeField] private List<Location> locationList;
    [SerializeField] private LocationScriptPath locationScriptPath;

    [Space]
    [Header("Mini Game")]
    [SerializeField] private GameObject miniGamePanelGO;
    //[SerializeField] private GameObject miniGamePanelGO;
    private int currentLocationIndex = -1;

    private void Start() {
        uiUsernameInputGO.SetActive(true);
        questPanelGO.SetActive(false);
        usernameInputHandler.SetOnProcessed(Start2);
    }

    private void Start2() {
        uiUsernameInputGO.SetActive(false);
        return;
        ShowLocation(0, () => {
            QuestManager.Instance.AddQuest(quests[0]);
            ShowLocation(1, () => {
                miniGamePanelGO.SetActive(true);
                miniGamePanelGO.GetComponent<CutSceneHandler>().SetOnFinished(() => {
                    miniGamePanelGO.SetActive(false);
                    ShowLocation(1, () => {
                        
                    });
                });
            });
        });
    }

    private void ShowLocation(int index, System.Action callback) {
        //close previous location
        if (currentLocationIndex != -1)
            locationList[currentLocationIndex].Hide();
        
        //show next one
        currentLocationIndex = index;
        locationList[currentLocationIndex].Show(callback);
    }

    private void Start3() {
        
    }
}
