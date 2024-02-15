using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeMarble : MonoBehaviour
{
    public GameObject Marble;
    public GameObject MarbleChoiceUI;
    //public Transform ButtonTransform;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Marble);
        //Marble.transform.position = transform.position;
        //    //Vector2(41.9000015, -67.1999969, 0);
        //Marble.transform.position = MarbleButton.transform.position;
    }

    void Update()
    {
        
    }

    public void MarbleOpen()
    {
        Marble.SetActive(true);
    }

    public void MarbleChoiceOpen()
    {
        MarbleChoiceUI.SetActive(true);
    }
    public void ButtonPosition(Transform button)
    {
        MarbleChoiceUI.transform.position = button.position;
        MarbleChoiceUI.transform.position = new Vector3(MarbleChoiceUI.transform.position.x, MarbleChoiceUI.transform.position.y + 150);

    }
}