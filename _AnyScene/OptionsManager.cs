using System.Numerics;

public static class OptionsManager
{
    public static bool FullScreen;
    public static Vector2 CurrentResolution;

    public static class ScreenResolution
    {
        public static readonly Vector2 FullHD = new Vector2(1920, 1080);
        public static readonly Vector2 QHD = new Vector2(2560, 1440);
        public static readonly Vector2 UHD = new Vector2(3840, 2160);
    }


}
