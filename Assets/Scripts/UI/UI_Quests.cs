using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Quests : MonoBehaviour
{

    [SerializeField] private Transform questPrefab, questContainer;

    private Dictionary<Quest, GameObject> uiQuestDictionary;


    private void Start() {
        uiQuestDictionary = new();

        foreach (Transform child in questContainer) {
            Destroy(child.gameObject);
        }

        QuestManager.Instance.OnQuestAdded += AddQuest;
        QuestManager.Instance.OnQuestCompleted += ClearQuest;
    }

    private void ClearQuest(Quest quest) {
        Dictionary<Quest, GameObject> uiQuestDictionaryCopy = new Dictionary<Quest, GameObject>(uiQuestDictionary);
        foreach (var questPair in uiQuestDictionaryCopy) {
            if (questPair.Key == quest) {
                questPair.Value.SetActive(false);
                uiQuestDictionary.Remove(quest);
            }
        }
    }

    private void AddQuest(Quest quest) {
        Transform questInstance = Instantiate(questPrefab, questContainer);
        questInstance.GetComponent<UI_QuestSingle>().SetQuestText(quest.questDescription);
        uiQuestDictionary.Add(quest, questInstance.gameObject);
    }
}
