using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class TextUI : MonoBehaviour
{
    private TextMeshProUGUI text;
    [SerializeField] private float showTime;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        text.text = "";
    }

    public void ShowText(string value)
    {
        StopAllCoroutines();
        StartCoroutine(ShowTextCoroutine(value));
    }

    IEnumerator ShowTextCoroutine(string value)
    {
        text.text = value;
        yield return new WaitForSeconds(showTime);
        if (showTime != 0) text.text = "";
    }
}