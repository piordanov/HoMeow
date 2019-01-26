using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunaCanController : ItemController
{
    // Start is called before the first frame update
    public override void OnStart()
    {
        rgb.velocity = new Vector3(10, 0, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
