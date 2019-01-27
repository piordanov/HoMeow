using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolboxCounter : MonoBehaviour
{
    public int toolboxPoints = 0;
    // Start is called before the first frame update
    

    // Update is called once per frame
    private void OnGUI()
    {
        Debug.Log("Hello");
        GUI.Label(new Rect(10, 10, 100, 20), " " + toolboxPoints);
    }
}
