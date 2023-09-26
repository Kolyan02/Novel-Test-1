using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public event System.Action<Quest> OnQuestAdded;
    public event System.Action<Quest> OnQuestCompleted;
    public static QuestManager Instance { get; private set; }

    public List<Quest> availableQuests {get; private set;}

    private void Awake() {
        Instance = this;

        availableQuests = new();
    }

    public void AddQuest(Quest quest) {
        availableQuests.Add(quest);
        OnQuestAdded?.Invoke(quest);
    }

    public void CompleteQuest(Quest quest) {
        for (int i = 0; i < availableQuests.Count; i++) {
            if (quest == availableQuests[i]) {
                availableQuests.RemoveAt(i);
                i--;
            }
        }
        OnQuestCompleted?.Invoke(quest);
    }
}
