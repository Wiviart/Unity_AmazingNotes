using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class UI_Text : MonoBehaviour
{
    protected TextMeshProUGUI text;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        text.text = "";
    }

    public void ShowText(string value, float time)
    {
        StopAllCoroutines();
        StartCoroutine(ShowTextCoroutine(value, time));
    }

    protected IEnumerator ShowTextCoroutine(string value, float time)
    {
        text.text = value;
        yield return new WaitForSeconds(time);
        if (time != 0) text.text = "";
    }
}