using UnityEngine;

public class ClickSound : MonoBehaviour
{
    public static ClickSound Instance { get; private set; }

    private AudioSource _sound;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _sound = GetComponent<AudioSource>();
    }

    public void PlayCoin()
    {
        _sound.Play();
    }
}
