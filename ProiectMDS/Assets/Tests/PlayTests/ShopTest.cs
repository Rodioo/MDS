using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using TMPro;
using System;

public class ShopTest
{
    // A Test behaves as an ordinary method
    [Test]
    public void ShopTest1()
    {
        var obj = new GameObject();
        var shop = obj.AddComponent<Shop1>();
        var text = obj.AddComponent<TextMeshProUGUI>();
        shop.priceText = text;
        shop.setPrice(1);
        Assert.AreEqual( Int32.Parse(shop.priceText.text), 1 );
    }
    [Test]
    public void ShopTest2()
    {
        var obj = new GameObject();
        var shop = obj.AddComponent<Shop2>();
        var text = obj.AddComponent<TextMeshProUGUI>();
        shop.priceText = text;
        shop.setPrice(1);
        Assert.AreEqual(Int32.Parse(shop.priceText.text), 1);
    }
    [Test]
    public void ShopTest3()
    {
        var obj = new GameObject();
        var shop = obj.AddComponent<Shop3>();
        var text = obj.AddComponent<TextMeshProUGUI>();
        shop.priceText = text;
        shop.setPrice(1);
        Assert.AreEqual(Int32.Parse(shop.priceText.text), 1);
    }

}
