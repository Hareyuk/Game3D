using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIInventory : MonoBehaviour
{
    public Inventory inventory;
    public Dictionary<string, Sprite> dicIcons = new Dictionary<string, Sprite>();
    public Sprite[] arraySprites;
    public string[] arrayTags;
    float posSelection;
    void Start()
    {
        for(int i = 0; i < arraySprites.Length;i++)
        {
            dicIcons.Add(arrayTags[i], arraySprites[i]);
        }
        RefreshInventory();
        posSelection = 0;
    } 

    public void RefreshInventory()
    {
        List<InteractiveObj> list = new List<InteractiveObj>(inventory.all);
        foreach(Transform child in transform)
        {
            if(list.Count > 0)
            {
                GameObject goChild = child.gameObject;
                goChild.SetActive(true);
                Image goImg = goChild.GetComponent<Image>();
                InteractiveObj obj = list[0];
                print("tag: " + obj.tag);
                print("Spite: " + dicIcons[obj.tag]);
                goImg.sprite = dicIcons[obj.tag];
                list.RemoveAt(0);
            }
            else
            {
                child.gameObject.SetActive(false);
            }
        }
    }
}
