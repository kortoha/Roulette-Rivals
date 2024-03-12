using System.Collections;
using TMPro;
using UnityEngine;

public class WheelItem : MonoBehaviour
{
    [SerializeField] private int _carryingChipCont;
    [SerializeField] private TextMeshProUGUI _carryingChipCountText;
    [SerializeField] private Transform _wheelParentTransform;

    [SerializeField] private Transform _blueChipFX;
    [SerializeField] private Transform _pinkChipFX;
    [SerializeField] private Transform _redChipFX;

    private bool _isFxOnce = false;

    public int CarryingChipCount
    {
        get { return _carryingChipCont; }
        set
        {
            _carryingChipCont = value;
            _carryingChipCountText.text = _carryingChipCont.ToString();
        }
    }

    public enum ChipTipe
    {
        Blue,
        Red,
        Pink
    }

    public ChipTipe chipTipe;

    private void Start()
    {
        _carryingChipCountText.text = _carryingChipCont.ToString();
    }

    public void WinChips()
    {
        switch (chipTipe)
        {
            case ChipTipe.Blue:
                MoneyManager.Instance.TakeBlueChips(_carryingChipCont);
                if (!_isFxOnce)
                {
                    SFXManager.Instance.PlaySound(SFXManager.Instance.blueChipWin);
                    Transform bfx = Instantiate(_blueChipFX, Vector2.zero, Quaternion.identity);
                    bfx.SetParent(_wheelParentTransform);
                    _isFxOnce = true;
                    StartCoroutine(DFX(bfx));
                }
                break;
            case ChipTipe.Red:
                MoneyManager.Instance.TakeRedChips(_carryingChipCont);
                if (!_isFxOnce)
                {
                    SFXManager.Instance.PlaySound(SFXManager.Instance._inkChipWin);
                    Transform pfx = Instantiate(_redChipFX, Vector2.zero, Quaternion.identity);
                    pfx.SetParent(_wheelParentTransform);
                    _isFxOnce = true;
                    StartCoroutine(DFX(pfx));
                }
                break;
            case ChipTipe.Pink:
                MoneyManager.Instance.TakePinkChips(_carryingChipCont);
                if (!_isFxOnce)
                {
                    SFXManager.Instance.PlaySound(SFXManager.Instance.returnChip);
                    Transform rfx = Instantiate(_pinkChipFX, Vector2.zero, Quaternion.identity);
                    rfx.SetParent(_wheelParentTransform);
                    _isFxOnce = true;
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
        _isFxOnce = false;
        Destroy(fx.gameObject);
    }
}
