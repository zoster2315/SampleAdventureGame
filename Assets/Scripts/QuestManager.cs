using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public Quest[] Quests;

    public static Quest.QUESTSTATUS GetQuestStatus(string questName)
    {
        foreach (Quest q in ThisInstance.Quests)
        {
            if (q.QuestName == questName)
                return q.Status;
        }

        return Quest.QUESTSTATUS.UNASSIGNED;
    }

    public static void SetQuestStatus(string questName, Quest.QUESTSTATUS newStatus)
    {
        foreach (Quest q in ThisInstance.Quests)
        {
            if (q.QuestName == questName)
            {
                q.Status = newStatus;
                return;
            }
        }
    }

    public static void Reset()
    {
        foreach (Quest q in ThisInstance.Quests)
        {
            q.Status = Quest.QUESTSTATUS.UNASSIGNED;
        }
    }

    private static QuestManager ThisInstance = null;

    private void Awake()
    {
        if (ThisInstance == null)
        {
            DontDestroyOnLoad(this);
            ThisInstance = this;
        }
        else
        {
            DestroyImmediate(gameObject);
        }
    }
}
