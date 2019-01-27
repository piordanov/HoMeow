using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Material planeMat;
    public Material waterMat;

    void Start()
    {
        ProceduralHelper.CreateRandomFloor(100, 100, 0, planeMat);
        ProceduralHelper.CreateRandomFloor(100, 100, 0, waterMat);
    }

}
