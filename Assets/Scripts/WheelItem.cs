using System.Collections;
using TMPro;
using UnityEngine;

public class WheelItem : MonoBehaviour
{
    [SerializeField] private int _cChC;
    [SerializeField] private TextMeshProUGUI _cCCT;
    [SerializeField] private Transform _wPT;

    [SerializeField] private Transform _bCFX;
    [SerializeField] private Transform _pCFX;
    [SerializeField] private Transform _rCFX;

    private bool _iFO = false;

    public int CCC
    {
        get { return _cChC; }
        set
        {
            _cChC = value;
            _cCCT.text = _cChC.ToString();
        }
    }

    public enum CT
    {
        B,
        R,
        P
    }

    public CT cT;

    private void Start()
    {
        _cCCT.text = _cChC.ToString();
    }

    public void WC()
    {
        switch (cT)
        {
            case CT.B:
                MoneyManager.Instance.TBC(_cChC);
                if (!_iFO)
                {
                    SFXManager.Instance.PlaySound(SFXManager.Instance.blueChipWin);
                    Transform bfx = Instantiate(_bCFX, Vector2.zero, Quaternion.identity);
                    bfx.SetParent(_wPT);
                    _iFO = true;
                    StartCoroutine(DFX(bfx));
                }
                break;
            case CT.R:
                MoneyManager.Instance.TRC(_cChC);
                if (!_iFO)
                {
                    SFXManager.Instance.PlaySound(SFXManager.Instance._inkChipWin);
                    Transform pfx = Instantiate(_rCFX, Vector2.zero, Quaternion.identity);
                    pfx.SetParent(_wPT);
                    _iFO = true;
                    StartCoroutine(DFX(pfx));
                }
                break;
            case CT.P:
                MoneyManager.Instance.TPC(_cChC);
                if (!_iFO)
                {
                    SFXManager.Instance.PlaySound(SFXManager.Instance.returnChip);
                    Transform rfx = Instantiate(_pCFX, Vector2.zero, Quaternion.identity);
                    rfx.SetParent(_wPT);
                    _iFO = true;
                    StartCoroutine(DFX(rfx));
                }
                break;
            default:
                break;
        }
    }

    private IEnumerator DFX(Transform fx)
    {
        yield return new WaitForSeconds(1.25f);
        _iFO = false;
        Destroy(fx.gameObject);
    }
}
