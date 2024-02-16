using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EquippedMarble : MonoBehaviour
{
    [SerializeField] private List<Image> _sprite;
    public static int[] IDnum = new int[5];

    // Start is called before the first frame update
    void Start()
    {
        List<MarbleInfo> temp = SlotManager.Instance.Inventory.FindAll(obj => obj.IsEquipped == true);
        for (int i = 0; i < temp.Count; i++)
            {
                if (temp[i] != null)
                {
                _sprite[i].sprite = temp[i].MarbleData.MarbleImage;
                IDnum[i] = temp[i].MarbleData.MarbleID;
                
                    if (SceneManager.GetActiveScene().name == "InventoryScene")
                    {
                    _sprite[i].AddComponent<Draggable>().ID = temp[i].MarbleData.MarbleID;
                    }
                }
            }
        // _sprite.sprite = temp.MarbleData.MarbleImage;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
