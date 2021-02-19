using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleSelect : MonoBehaviour
{
    public Vector3 posOld;
    public bool play = true;
    // Start is called before the first frame update
    void Start()
    {
        posOld = transform.position;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.position = new Vector3(transform.position.x, -1.41f);
            play = false;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position = posOld;
            play = true;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(play == true)
            {
                SceneManager.LoadScene("SampleScene");
            }
            if(play == false)
            {
                Application.Quit();
            }

        }
        
    }
}
