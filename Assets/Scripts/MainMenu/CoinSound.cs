using UnityEngine;

public class CoinSound : MonoBehaviour
{
    public static CoinSound Instance { get; private set; }

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
