using System.Collections;
using UnityEngine;

public class ToolboxCounter : MonoBehaviour
{
    private int count;
    // Start is called before the first frame update

    void Start()
    {
        count = 0;
        OnGUI();
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 100, 20), "Hello World!");
    }
}
