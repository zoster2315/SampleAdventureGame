[System.Serializable]
public class Quest
{
    public enum QUESTSTATUS {UNASSIGNED, ASSIGNED, COMPLETE };
    public QUESTSTATUS Status = QUESTSTATUS.UNASSIGNED;
    public string QuestName = string.Empty;
}
