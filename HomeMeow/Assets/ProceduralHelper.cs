using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProceduralHelper
{
  /**
   * CREATE RANDOM FLOOR
   */
  public static GameObject CreateRandomFloor(int width, int height, int subdivisions, Material material, int[,] world) {
    GameObject go = new GameObject("Ground");
    MeshFilter mf = go.AddComponent<MeshFilter>();
    MeshRenderer mr = go.AddComponent<MeshRenderer>();
    MeshCollider mc = go.AddComponent<MeshCollider>();
    Mesh m = createMesh(width, height, subdivisions, world);
    
    mr.material = material;
    mf.mesh = m;
    mc.sharedMesh = m;

    GameObject.Instantiate(go, new Vector3(0, 0, 0), new Quaternion());

    return go;
  }

  private static Vector3[] generateVertices(int width, int height, int subdivisions, int[,] world) {
    int rows = width + width * subdivisions;
    int columns = height + height * subdivisions;

		int verticesInRow = width + 1;
		int verticesInColumn = height + 1;

		int numVertices = verticesInRow * verticesInColumn;
    Vector3[] vertices = new Vector3[numVertices];

    int idx = 0;
		for (int vertexZ = 0; vertexZ < verticesInColumn; vertexZ++) {
			for (int vertexX = 0; vertexX < verticesInRow; vertexX++) {
        float d = subdivisions + 1f;
        float x = 1f * vertexX / d;
        float y = world[vertexX, vertexZ];
        float z = 1f * vertexZ / d;

        Vector3 vertex = new Vector3();
        vertex.x = x;
        vertex.y = y;
        vertex.z = z;

        // vertices[vertexZ * rows + vertexX] = vertex;
        vertices[idx++] = vertex;
			}
		}

		return vertices;
  }

  private static int[] generateTriangles(int width, int height) {
    int verticesInColumn = height + 1;
    int verticesInRow = width + 1;
    
    int numberOfTriangles = width * height * 2;
    int componentsPerTriangle = 3;
    int[] triangles = new int[numberOfTriangles * componentsPerTriangle];

    int idx = 0;
    for (int z = 0; z < verticesInColumn - 1; z++) {
      for (int x = 0; x < verticesInRow - 1; x++) {
        triangles[idx++] = (x) + (z * verticesInColumn);
        triangles[idx++] = (x + 1) + ((z + 1) * (verticesInColumn));
        triangles[idx++] = (x) + ((z + 1) * (verticesInColumn));

        triangles[idx++] = (x) + (z * verticesInColumn);
        triangles[idx++] = (x + 1) + (z * verticesInColumn);
        triangles[idx++] = (x + 1) + ((z + 1) * (verticesInColumn));
      }
    }

    return triangles;
  }

  private static Vector2[] generateUV(int width, int height, int subdivisions) {
    int rows = width + width * subdivisions;
    int columns = height + height * subdivisions;

		int verticesInRow = width + 1;
		int verticesInColumn = height + 1;

    Vector2[] uv = new Vector2[verticesInColumn * verticesInRow];
    
    int idx = 0;
    for (int x = 0; x < verticesInColumn; x++) {
      for (int z = 0; z < verticesInRow; z++) {
        Vector2 texCoords = new Vector2();
        texCoords[0] = x / (verticesInRow - 1);
        texCoords[1] = z / (verticesInColumn - 1);
        uv[idx++] = texCoords;
      }
    }
    
    return uv;
  }

  private static Mesh createMesh(int width, int height, int subdivisions, int[,] world) {
    Mesh m = new Mesh();

    m.vertices = generateVertices(width, height, subdivisions, world);
    m.uv = generateUV(width, height, subdivisions);
    m.triangles = generateTriangles(width, height);
    
    m.RecalculateBounds();
    m.RecalculateNormals();

    return m;
  }

}
