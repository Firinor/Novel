using System;
using System.Collections.Generic;
using UnityEditor;

public static class LanguageInformator
{
    // 0 - ������� ����
    // 1 - English language
    private static Dictionary<string, string[]> Texts
        = new Dictionary<string, string[]>()
        {
            ["Play"] = 
            Words( "�����", "Start"),

            ["Options"] = 
            Words( "���������", "Options" ),

            ["Credits"] = 
            Words( "���������" , "Credits" ),

            ["Exit"] = 
            Words("�����" , "Exit" ),

            ["Return"] = 
            Words( "�������" , "Return" ),

            ["Creators"] = 
            Words("�����������: ��� ������� ��������\n\n" +
                "��������: ������ ��������",
                "Developer: sir Firinor Hisimeon\n\n" +
                "Narrative: Marina Knyshenko"),

            ["OptionsFullScreen"] = 
            Words( "���� �����" , "Full screen"),

            ["OptionsScreenResolution"] = 
            Words( "���������� ������" , "Screen resolution" ),

            ["OptionsVolume"] = 
            Words( "����" , "Volume" ),

            ["OptionsMouseSensitivity"] = 
            Words( "���������������� ����" , "Mouse sensitivity" ),

            ["OptionsLanguage"] = 
            Words( "����" , "Language" ),

            ["Empty"] =
            Words("�����", "Empty"),

            ["RestoreDefaults"] =
            Words("�������� �� ���������", "Restore defaults"),
        };

    private static string[] Words(string ru, string en)
    {
        return new string[] { ru, en };
    }

    public static string GetText(string key)
    {
        return GetText(key, PlayerManager.Language);
    }

    private static string GetText(string key, Languages language)
    {
        if(Texts.ContainsKey(key))
            return Texts[key][(int)language];

        throw new Exception();
    }
}
