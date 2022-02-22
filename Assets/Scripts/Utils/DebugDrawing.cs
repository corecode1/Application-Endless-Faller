using UnityEngine;

namespace EndlessFaller.Utils
{
    public static class DebugDrawing
    {
        public static void DrawRect(Vector2 center, Vector2 size, float duration = 0f)
        {
            Color color = new Color(1f, 0f, 0f);

            Vector2 halfSize = size / 2;
            Vector2 topLeft = center + new Vector2(-halfSize.x, halfSize.y);
            Vector2 topRight = center + new Vector2(halfSize.x, halfSize.y);
            Vector2 bottomLeft = center + new Vector2(-halfSize.x, -halfSize.y);
            Vector2 bottomRight = center + new Vector2(halfSize.x, -halfSize.y);

            Debug.DrawLine(topLeft, topRight, color, duration);
            Debug.DrawLine(topRight, bottomRight, color, duration);
            Debug.DrawLine(bottomRight, bottomLeft, color, duration);
            Debug.DrawLine(bottomLeft, topLeft, color, duration);
        }

        public static void DrawRect(Rect rect, float duration = 0f)
        {
            Color color = new Color(1f, 0f, 0f);

            Vector2 halfSize = rect.size / 2;
            Vector2 topLeft = rect.center + new Vector2(-halfSize.x, halfSize.y);
            Vector2 topRight = rect.center + new Vector2(halfSize.x, halfSize.y);
            Vector2 bottomLeft = rect.center + new Vector2(-halfSize.x, -halfSize.y);
            Vector2 bottomRight = rect.center + new Vector2(halfSize.x, -halfSize.y);

            Debug.DrawLine(topLeft, topRight, color, duration);
            Debug.DrawLine(topRight, bottomRight, color, duration);
            Debug.DrawLine(bottomRight, bottomLeft, color, duration);
            Debug.DrawLine(bottomLeft, topLeft, color, duration);
        }

        public static void DrawBounds(Bounds b, float duration = 0f)
        {
            // bottom
            Vector3 p1 = new Vector3(b.min.x, b.min.y, b.min.z);
            Vector3 p2 = new Vector3(b.max.x, b.min.y, b.min.z);
            Vector3 p3 = new Vector3(b.max.x, b.min.y, b.max.z);
            Vector3 p4 = new Vector3(b.min.x, b.min.y, b.max.z);

            Debug.DrawLine(p1, p2, Color.blue, duration);
            Debug.DrawLine(p2, p3, Color.red, duration);
            Debug.DrawLine(p3, p4, Color.yellow, duration);
            Debug.DrawLine(p4, p1, Color.magenta, duration);

            // top
            Vector3 p5 = new Vector3(b.min.x, b.max.y, b.min.z);
            Vector3 p6 = new Vector3(b.max.x, b.max.y, b.min.z);
            Vector3 p7 = new Vector3(b.max.x, b.max.y, b.max.z);
            Vector3 p8 = new Vector3(b.min.x, b.max.y, b.max.z);

            Debug.DrawLine(p5, p6, Color.blue, duration);
            Debug.DrawLine(p6, p7, Color.red, duration);
            Debug.DrawLine(p7, p8, Color.yellow, duration);
            Debug.DrawLine(p8, p5, Color.magenta, duration);

            // sides
            Debug.DrawLine(p1, p5, Color.white, duration);
            Debug.DrawLine(p2, p6, Color.gray, duration);
            Debug.DrawLine(p3, p7, Color.green, duration);
            Debug.DrawLine(p4, p8, Color.cyan, duration);
        }
    }
}