using UnityEngine;
using UnityEngine.UI;

public class TransitionBetweenFields : MonoBehaviour
{
    [SerializeField] private GameObject _wp; 
    [SerializeField] private GameObject _tp; 
    [SerializeField] private Button _tb; 
    [SerializeField] private Image _bi; 

    [SerializeField] private Sprite _tts; 
    [SerializeField] private Sprite _fts; 

    private bool _ito = false;

    private void Start()
    {
        _tb.onClick.AddListener(TP);
    }

    private void OT()
    {
        _wp.SetActive(false);
        _tp.SetActive(true);
        _ito = true;
        _bi.sprite = _fts;
    }

    private void OW()
    {
        _wp.SetActive(true);
        _tp.SetActive(false);
        _ito = false;
        _bi.sprite = _tts;
    }

    private void TP()
    {
        if (_ito)
        {
            Fader.Instance.PlayeFadeAnim();
            Invoke("OW", 0.51f);
        }
        else
        {
            Fader.Instance.PlayeFadeAnim();
            Invoke("OT", 0.51f);
        }
    }
}
