public static class PlayerManager
{
    public static int Account;

    private static Languages language;
    public static Languages Language
    {
        get
        {
            return language;
        }
        set
        {
            language = value;
            LanguageManager.ChangeLanguage();
        }
    }

    public static void OnLoad()
    {
        Account = SaveManager.PlayerAccount();
    }
}
