using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BugsLeft : MonoBehaviour
{
    public Canvas canvas;
    public Text text;
    public int bugsLeft;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        text.text = "Bugs Left: " + bugsLeft;

        
    }
}
