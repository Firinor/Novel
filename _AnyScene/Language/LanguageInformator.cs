using System.Collections.Generic;

public static class LanguageInformator
{
    private static Dictionary<string, Dictionary<Languages, string>> Texts
        = new Dictionary<string, Dictionary<Languages, string>>()
    {
            ["Play"] = { { Languages.RU, "Старт" }, { Languages.EN, "Start" } },
            ["Options"] = { { Languages.RU, "Настройки" }, { Languages.EN, "Options" } },
            ["Credits"] = { { Languages.RU, "Создатели" }, { Languages.EN, "Credits" } },
            ["Exit"] = { { Languages.RU, "Выход" }, { Languages.EN, "Exit" } },
            ["Return"] = { { Languages.RU, "Продолжить" }, { Languages.EN, "Return" } },
            ["Creators"] = { { 
                    Languages.RU, "Разработчик: сир Фиринор Хисимеон" }, { 
                    Languages.EN, "Developer: sir Firinor Hisimeon" } },
            ["OptionsFullScreen"] = { { Languages.RU, "Настройки" }, { Languages.EN, "Options" } },
            ["OptionsScreenResolution"] = { { Languages.RU, "Расширение экрана" }, { Languages.EN, "Screen resolution" } },
            ["OptionsVolume"] = { { Languages.RU, "Звук" }, { Languages.EN, "Volume" } },
            ["OptionsMouseSensitivity"] = { { Languages.RU, "Чувствительность мыши" }, { Languages.EN, "Mouse sensitivity" } },
            ["OptionsLanguage"] = { { Languages.RU, "Язык" }, { Languages.EN, "Language" } },
        };

    public static string GetText(string name, Languages language)
    {
        return Texts[name][language];
    }
}
