using System;
using System.Collections;
using AmazingNotes.Game;
using UnityEngine;
using UnityEngine.UI;

public class CheerNotification : MonoBehaviour
{
    [SerializeField] private Sprite[] Cheers;
    private Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = false;
    }

    private void OnEnable()
    {
        Observer.OnClick += ShowCheerClick;
        Observer.OnHold += ShowCheerHold;
    }

    private void OnDisable()
    {
        Observer.OnClick -= ShowCheerClick;
        Observer.OnHold -= ShowCheerHold;
    }

    private void ShowCheerClick(int index)
    {
        StopAllCoroutines();
        StartCoroutine(ShowCheerCoroutine(index));
    }

    private void ShowCheerHold(int score)
    {
        var index = score / 2;
        StopAllCoroutines();
        StartCoroutine(ShowCheerCoroutine(index));
    }

    private IEnumerator ShowCheerCoroutine(int score)
    {
        var cheer = Cheers[score - 1];
        image.enabled = true;
        image.sprite = cheer;
        yield return new WaitForSeconds(1f);
        image.enabled = false;
    }
}