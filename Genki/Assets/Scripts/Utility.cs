using UnityEngine;

namespace Genki.Utility
{
    public class UtilityFunction
    {
        public static Vector2 Rotate(Vector2 v, float degrees) {
            float sin = Mathf.Sin(degrees * Mathf.Deg2Rad);
            float cos = Mathf.Cos(degrees * Mathf.Deg2Rad);
         
            float tx = v.x;
            float ty = v.y;
            v.x = (cos * tx) - (sin * ty);
            v.y = (sin * tx) + (cos * ty);
            return v;
        }

        public static Vector2 Transport(Vector2 v, Vector2 center)
        {
            return v - center;
        }

        public static Vector2 Rotate(Vector2 v, Vector2 center, float degree)
        {
            Vector2 v2 = Transport(v, center);
            Vector2 rotatedV2 = Rotate(v2, degree);
            Vector2 rotatedV = Transport(rotatedV2, -center);
            return rotatedV;
        }
    }
}