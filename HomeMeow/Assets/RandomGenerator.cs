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

    public static Vector2 pointOnCircle(int centerX, int centerY, int radius) {
        float theta = Random.value * 2 * Mathf.PI;
        float x = centerX + radius * Mathf.Cos(theta);
        float y = centerY + radius * Mathf.Sin(theta);
        return new Vector2(x, y);
    }

    public static Vector2[] points(int amount, int startX, int endX, int startY, int endY) {
        Vector2[] points = new Vector2[amount];

        for(int i = 0; i < points.Length; i++) {
            points[i] = point(startX, endX, startY, endY);
        }

        return points;
    }

    public static int[,] createWorld(int width, int height) {
        int[,] world = new int[width+1, height+1];

        Vector2 point = RandomGenerator.point(0, width+1, 0, height+1);
        int radius = (int)RandomGenerator.between(4, 10);
        
        for (int z = -radius; z <= radius; z++) {
            for (int x = -radius; x<=radius; x++) {
                if (x*x + z*z <= radius*radius) {
                    if (point.x+x >= 0 && point.y+z >= 0 && point.x+x < width+1 && point.y+z < height+1) {
                        world[(int)point.x+x, (int)point.y+z] = -1;
                    }
                }
            }
        }

        // for(int i = 0; i < itemSpawnPerIsland)
        // for (bool found = false; found != true; ) {
            // Vector2 spawnPoint = 
        // }
        
        for (int z = -radius; z <= radius; z++) {
            for (int x = -radius; x<=radius; x++) {
                if (x*x + z*z <= radius*radius) {
                    if (point.x+x >= 0 && point.y+z >= 0 && point.x+x < width+1 && point.y+z < height+1) {
                        world[(int)point.x+x, (int)point.y+z] = -1;
                    }
                }
            }
        }

        return world;
    }

}