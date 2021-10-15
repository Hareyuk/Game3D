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
    public Player player;
    InteractiveObj lastFrameItem;

    void Start()
    {
        for(int i = 0; i < arraySprites.Length;i++)
        {
            dicIcons.Add(arrayTags[i], arraySprites[i]);
        }
        posSelection = 0;
        RefreshInventory();
    }

    private void Update()
    {
        bool mouseWheelPassed = false;
        if (inputManager.axisMouse < 0f)
        {
            print("cantidad de items:" + inventory.all.Count + " - position: " + positionInventory);
            if(positionInventory < inventory.all.Count-1)
            {
                positionInventory++;
                mouseWheelPassed = true;
            }
        }
        else if (inputManager.axisMouse > 0f) 
        {
            if (positionInventory > 0)
            {
                positionInventory--;
                mouseWheelPassed = true;
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
        if(mouseWheelPassed)
        {
            HighlightSelectedItem();
        }
    }

    public InteractiveObj ReturnObj()
    {
        return inventory.all[(int)posSelection];
    }


    public void HighlightSelectedItem()
    {
        int i = 0;
        foreach (Transform child in transform)
        {/*
            GameObject goChild = child.gameObject;
            InteractiveObj io = inventory.all[positionInventory];
            GameObject go = io.gameObject;
            if (goChild.name == "Image" + (positionInventory + 1))
            {
                foreach (Transform childImg in goChild.transform)
                {
                    childImg.gameObject.SetActive(true);
                }
                if (lastFrameItem != io)
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
                if (inventory.all.Count > positionInventory)
                {
                    go.SetActive(false);
                }
            }*/
            GameObject goChild = child.gameObject;
            if (inventory.all.Count > i)
            {
                InteractiveObj ioInventory = inventory.all[i];
                if (child.name == "Image" + (positionInventory + 1))
                {
                    foreach (Transform childImg in goChild.transform)
                    {
                        childImg.gameObject.SetActive(true);
                    }
                    if (ioInventory)
                    {
                        ioInventory.gameObject.SetActive(true);
                        player.ioUsing = ioInventory;
                    }
                }
                else
                {
                    foreach (Transform childImg in goChild.transform)
                    {
                        childImg.gameObject.SetActive(false);
                    }
                    ioInventory.gameObject.SetActive(false);
                }
            }
            else
            {
                foreach (Transform childImg in goChild.transform)
                {
                    childImg.gameObject.SetActive(false);
                }
            }
            i++;
        }
    }

    public void RefreshInventory()
    {
        List<InteractiveObj> list = new List<InteractiveObj>(inventory.all);
        foreach(Transform child in transform)
        {
            GameObject goChild = child.gameObject;
            goChild.SetActive(true);
            Image goImg = goChild.GetComponent<Image>();
            if(list.Count > 0)
            {
                InteractiveObj obj = list[0];
                goImg.sprite = dicIcons[obj.GetComponent<Pickup>().tagName];
                list.RemoveAt(0);
            }
        }
        HighlightSelectedItem();
    }
}
