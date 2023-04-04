using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShowValue : MonoBehaviour
{
    Slider slider;
    TextMeshProUGUI text;
    private void Start()
    {
        slider = transform.parent.parent.parent.GetComponent<Slider>();
        text = GetComponent<TextMeshProUGUI>();
    }
    // Update is called once per frame
    void Update()
    {
        text.text = slider.value.ToString();
    }
}
