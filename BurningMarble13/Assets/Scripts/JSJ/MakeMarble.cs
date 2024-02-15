using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeMarble : MonoBehaviour
{
    public GameObject Marble;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Marble);
        //Marble.transform.position = transform.position;
        //    //Vector2(41.9000015, -67.1999969, 0);
        //Marble.transform.position = MarbleButton.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MarbleOpen()
    {
        Marble.SetActive(true);
    }
}