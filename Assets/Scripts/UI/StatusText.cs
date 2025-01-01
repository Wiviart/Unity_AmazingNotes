using System;
using TMPro;
using UnityEngine;

public class StatusText : MonoBehaviour
{
    private static TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    public static void SetText(string value)
    {
        text.text = value;
    }
}