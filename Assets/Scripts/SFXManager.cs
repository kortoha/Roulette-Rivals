using UnityEngine;

public class SFXManager : MonoBehaviour
{
    public static SFXManager Instance { get; private set; }

    public AudioClip blueChipWin;
    public AudioClip _inkChipWin;
    public AudioClip redChipWin;

    public AudioClip plusTenPers;
    public AudioClip freeSpin;

    public AudioClip returnChip;
    public AudioClip _void;
    public AudioClip winMoney;
    public AudioClip moneySFX;
    public AudioClip twoX;

    private void Awake()
    {
        Instance = this;
    }

    public void PlaySound(AudioClip audioClip)
    {
        AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position);
    }
}
