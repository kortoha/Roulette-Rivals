using UnityEngine;

public class Fader : MonoBehaviour
{
    public static Fader Instance { get; private set; }

    private Animator _animator;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    public void PlayeFadeAnim()
    {
        _animator.SetTrigger("Fade");
    }
}
