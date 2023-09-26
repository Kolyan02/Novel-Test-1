using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_QuestSingle : MonoBehaviour
{
    [SerializeField] private Text questText;

    public void SetQuestText(string questString) {
        questText.text = questString;
    }
}
