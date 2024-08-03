
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

        public float musicVolume;
        public float environmentVolume;
        public float effectsVolume;
        public float sentitivity;
        public int usersLanguage;
    }
}
