using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Script to update item information.
public class ItemInfoUpdate : MonoBehaviour
{
    public GameObject infoPanel;

    public Text nameText;
    public Image icon;
    public Text Description;

    //Function to receive item values and display item information.
    public void UpdateInfoPanel(Item itemInfo)
    {

        if (itemInfo != null)
        {
            infoPanel.SetActive(true);

            nameText.text = itemInfo.itemName;
            icon.sprite = itemInfo.itemIcon;
            Description.text = itemInfo.Description;
        }
        else
        {
            infoPanel.SetActive(false);
        }
    }

    public void ClosePanel()
    {
        infoPanel.SetActive(false);
    }
}
