using UnityEngine;

public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    private Animator _a;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _a = GetComponent<Animator>();
    }

    public void PFA()
    {
        _a.SetTrigger("Fade");
    }
}
