using UnityEngine;

namespace FirMath
{
    public static class GameTransform
    {
        public static Vector2 GetGlobalPoint(Transform transform)
        {
            return Camera.main.WorldToScreenPoint(transform.position);
        }
    }
}
