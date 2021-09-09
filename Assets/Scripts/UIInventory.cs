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
    public InputManager inputManager;
    [SerializeField]
    public int positionInventory = 0;
    public Character player;
    InteractiveObj lastFrameItem;

    void Start()
    {
        for(int i = 0; i < arraySprites.Length;i++)
        {
            dicIcons.Add(arrayTags[i], arraySprites[i]);
        }
        RefreshInventory();
        posSelection = 0;
    }

    private void Update()
    {
        if (inputManager.axisMouse < 0f)
        {
            print("cantidad de items:" + inventory.all.Count);
            if(positionInventory < inventory.all.Count-1)
            {
                positionInventory++;
            }    
        }
        else if (inputManager.axisMouse > 0f) 
        {
            if (positionInventory > 0)
            {
                positionInventory--;
            }
        }
        if (positionInventory > 5)
        {
            positionInventory = 5;
        }
        else if (positionInventory < 0)
        {
            positionInventory = 0;
        }
        HighlightSelectedItem();
    }

    public InteractiveObj ReturnObj()
    {
        return inventory.all[(int)posSelection];
    }


    void HighlightSelectedItem()
    {
        foreach (Transform child in transform)
        {
            GameObject goChild = child.gameObject;
            if(positionInventory >= inventory.all.Count)
            {
                break;
            }
            InteractiveObj io = inventory.all[positionInventory];
            GameObject go = io.gameObject;
            if (goChild.name == "Image" + (positionInventory + 1))
            {
                foreach (Transform childImg in goChild.transform)
                {
                    childImg.gameObject.SetActive(true);
                }
                if(lastFrameItem != io)
                {
                    inventory.ChangeItemHand();
                }
                else
                {
                    lastFrameItem = io;
                }
            }
            else
            {
                foreach (Transform childImg in goChild.transform)
                {
                    childImg.gameObject.SetActive(false);
                }
                if(inventory.all.Count > positionInventory)
                {
                    go.SetActive(false);
                }
            }
        }
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
                //print("tag: " + obj.tag);
                //print("Sprite: " + dicIcons[obj.tag]);
                print(obj.GetComponent<Pickup>().tagName);
                goImg.sprite = dicIcons[obj.GetComponent<Pickup>().tagName];
                list.RemoveAt(0);
            }
        }
    }
}
