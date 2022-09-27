using System;
using System.Collections.Generic;
using UnityEditor;

public static class LanguageInformator
{
    // 0 - Русский язык
    // 1 - English language
    private static Dictionary<string, string[]> Texts
        = new Dictionary<string, string[]>()
        {
            ["Play"] = 
            Words( "Старт", "Start"),

            ["Options"] = 
            Words( "Настройки", "Options" ),

            ["Credits"] = 
            Words( "Создатели" , "Credits" ),

            ["Exit"] = 
            Words("Выход" , "Exit" ),

            ["Return"] = 
            Words( "Возврат" , "Return" ),

            ["Creators"] = 
            Words("Разработчик: сир Фиринор Хисимеон\n\n" +
                "Сценарий: Марина Кнышенко",
                "Developer: sir Firinor Hisimeon\n\n" +
                "Narrative: Marina Knyshenko"),

            ["OptionsFullScreen"] = 
            Words( "Весь экран" , "Full screen"),

            ["OptionsScreenResolution"] = 
            Words( "Расширение экрана" , "Screen resolution" ),

            ["OptionsVolume"] = 
            Words( "Звук" , "Volume" ),

            ["OptionsMouseSensitivity"] = 
            Words( "Чувствительность мыши" , "Mouse sensitivity" ),

            ["OptionsLanguage"] = 
            Words( "Язык" , "Language" ),

            ["Empty"] =
            Words("Пусто", "Empty"),

            ["RestoreDefaults"] =
            Words("Сбросить по умолчанию", "Restore defaults"),
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
