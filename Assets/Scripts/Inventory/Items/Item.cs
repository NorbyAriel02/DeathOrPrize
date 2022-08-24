using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Item : MonoBehaviour
{    
    public ItemModel item;
    public Image image;    
    public virtual void SetItem(ItemModel value)
    {
        item = value;
        image.sprite = SpriteList.GetSprite(value.sprite, value.level);
    }
}
