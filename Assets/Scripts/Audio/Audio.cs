using UnityEngine;

public class Audio : MonoBehaviour
{
    [SerializeField] private SoundData data;

    private AudioSource _source;

    private void Awake()
    {
        _source = GetComponent<AudioSource>();
    }

    private void Start()
    {
        _source.clip = data.backgroundClips[Random.Range(0, data.backgroundClips.Count)];
        _source.Play();
    }
}