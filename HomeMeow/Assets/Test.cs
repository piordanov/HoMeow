﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public Material planeMat;
    public Material waterMat;

    void Start()
    {
        World world = new World(planeMat, waterMat);
        world.build();
    }

}
