using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MakeMarble : MonoBehaviour
{
    public GameObject Marble;
    public GameObject MarbleChoiceUI;
    //public Transform ButtonTransform;

    [HideInInspector]
    public static GameObject pushObj;

    [SerializeField]
    private GameObject[] MarblePrefabs;

    Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate(Marble);
        //Marble.transform.position = transform.position;
        //    //Vector2(41.9000015, -67.1999969, 0);
        //Marble.transform.position = MarbleButton.transform.position;

        mainCamera = Camera.main;
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
    public void MarbleChoiceClose()
    {
        MarbleChoiceUI.SetActive(false);
    }
    public void ButtonPosition(GameObject button)
    {
        MarbleChoiceUI.transform.position = button.transform.position;
        MarbleChoiceUI.transform.position = new Vector3(MarbleChoiceUI.transform.position.x, MarbleChoiceUI.transform.position.y - 110);

        if (pushObj == null)
        {
            pushObj = button;
        }
        else
        {
            pushObj = null;
            pushObj = button;
        }

    }
    public void GetMarblidId(int index)
    {
        int ID = EquippedMarble.IDnum[index] - 1;

        GameObject clone = Instantiate(MarblePrefabs[ID]);

        Vector3 tempPos = MarbleChoiceUI.transform.position;
        tempPos.y += 110;

        Vector3 pos = mainCamera.ScreenToWorldPoint(tempPos);
        pos.z = 0;

        clone.transform.position = pos;

    }


}