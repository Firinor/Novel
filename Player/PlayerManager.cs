using System;

public static class PlayerManager
{
    public static int Account;
    public static int Language;

    public static void OnLoad()
    {
        Account = SaveManager.PlayerAccount();
    }
}
