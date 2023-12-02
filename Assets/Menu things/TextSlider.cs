using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TextSlider : MonoBehaviour
{
    public TextMeshProUGUI numberText;
    // Start is called before the first frame update
    public void SetNumberText(float value)
    {
        numberText.text = Math.Round(value,2).ToString();
    }
}
