using System;
using UnityEngine;


[Serializable]
public class ShopImages
{
    public ShopImages(ShopeType shopName, Sprite[] shopImages)
    {
        this.shopName = shopName;
        this.shopImages = shopImages;
    }

    public ShopeType shopName;
    public Sprite[] shopImages;
}
