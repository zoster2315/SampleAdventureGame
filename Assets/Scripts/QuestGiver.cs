using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public string QuestName = string.Empty;
    public Text Caption = null;
    public string[] CaptionText;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player"))
        {
            return;
        }
        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        Caption.text = CaptionText[(int) Status];
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Quest.QUESTSTATUS Status = QuestManager.GetQuestStatus(QuestName);
        if (Status == Quest.QUESTSTATUS.UNASSIGNED)
        {
            QuestManager.SetQuestStatus(QuestName, Quest.QUESTSTATUS.ASSIGNED);
        }
        else if (Status == Quest.QUESTSTATUS.COMPLETE)
        {
            SceneManager.LoadScene(5);
        }
    }
}
