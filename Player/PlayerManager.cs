using System;

public static class PlayerManager
{
    public static int Account;
    public static Languages Language;

    public static void OnLoad()
    {
        Account = SaveManager.PlayerAccount();
    }
}
