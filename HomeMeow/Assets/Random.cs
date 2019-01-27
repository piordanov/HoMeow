using UnityEngine;

public static class RandomGenerator {
    public static float between(int start, int end) {
        return Random.value * (end - start) + start;
    }

    public static Vector2 point(int startX, int endX, int startY, int endY) {
        Vector2 point = new Vector2();
        point.x = between(startX, endX);
        point.y = between(startY, endY);
        return point;
    }

    public static Vector2[] points(int amount, int startX, int endX, int startY, int endY) {
        Vector2[] points = new Vector2[amount];

        for(int i = 0; i < points.Length; i++) {
            points[i] = point(startX, endX, startY, endY);
        }

        return points;
    }

}