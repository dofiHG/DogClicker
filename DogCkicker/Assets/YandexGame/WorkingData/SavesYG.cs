
namespace YG
{
    [System.Serializable]
    public class SavesYG
    {
        // "Технические сохранения" для работы плагина (Не удалять)
        public int idSave;
        public bool isFirstSession = true;
        public string language = "ru";
        public bool promptDone;

        public long bonesCount;
        public long bonesPerSecond;
        public long bonesPerClick;
        public int CurrentLevel;
        public int usersLanguage;
    }
}
