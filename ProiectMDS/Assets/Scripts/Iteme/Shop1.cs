using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Shop1 : MonoBehaviour
{

    public TextMeshProUGUI priceText;

    public void setPrice(int gold)
    {
        if (gold <= 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
            priceText.SetText(gold.ToString());

        }
    }

}
