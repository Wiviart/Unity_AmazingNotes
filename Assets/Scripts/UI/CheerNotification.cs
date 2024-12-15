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

    private void Start()
    {
        Observer.Instance.OnClick += ShowCheerClick;
        Observer.Instance.OnHold += ShowCheerHold;
    }

    private void OnDisable()
    {
        Observer.Instance.OnClick -= ShowCheerClick;
        Observer.Instance.OnHold -= ShowCheerHold;
    }

    private void ShowCheerClick(int index)
    {
        StopAllCoroutines();
        StartCoroutine(ShowCheerCoroutine(index - 1));
    }

    private void ShowCheerHold(int score)
    {
        var index = score / 2;
        ShowCheerClick(index);
    }

    private IEnumerator ShowCheerCoroutine(int index)
    {
        var sprite = Cheers[index];
        image.sprite = sprite;
        image.enabled = true;
        yield return new WaitForSeconds(1f);
        image.enabled = false;
    }
}