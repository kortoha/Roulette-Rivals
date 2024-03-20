using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusCards : MonoBehaviour
{
    private const string CI = "Choose"; 

    [SerializeField] private Cell[] _cA; 
    [SerializeField] private WheelItem[] _wIA; 

    [SerializeField] private Button _lCB; 
    [SerializeField] private Button _rCB; 

    [SerializeField] private Animator _lCA; 
    [SerializeField] private Animator _rCA; 

    [SerializeField] private int _lCP = 100; 
    [SerializeField] private int _rCP = 300; 

    [SerializeField] private TextMeshProUGUI _lCPT; 
    [SerializeField] private TextMeshProUGUI _rCPT;

    [SerializeField] private Transform _tPP;

    [SerializeField] private Transform _tPFX;
    [SerializeField] private Transform _rCFX;

    private void Start()
    {
        _lCB.onClick.AddListener(() => { RLC(); });
        _rCB.onClick.AddListener(() => { IW(); });

        _lCPT.text = _lCP.ToString();
        _rCPT.text = _rCP.ToString();
    }

    private void RLC()
    {
        if (MoneyManager.Instance.GC() >= _lCP)
        {
            MoneyManager.Instance.BFM(_lCP);
            SFXManager.Instance.PlaySound(SFXManager.Instance.returnChip);
            foreach (Cell i in _cA)
            {
                i.ReturnLoseMoney();
            }
            Transform fx = Instantiate(_rCFX, Vector2.zero, Quaternion.identity);
            fx.SetParent(_tPP);

            StartCoroutine(DFX(fx));

            _lCA.SetTrigger(CI);
            _lCPT.gameObject.SetActive(false);
        }
    }

    private void IW()
    {
        if (MoneyManager.Instance.GC() >= _rCP)
        {
            SFXManager.Instance.PlaySound(SFXManager.Instance.plusTenPers);
            MoneyManager.Instance.BFM(_rCP);
            float pI = 0.10f;

            foreach (WheelItem i in _wIA)
            {
                int iC = (int)(i.CCC * (1 + pI));
                i.CCC = iC;
            }

            Transform fx = Instantiate(_tPFX, Vector2.zero, Quaternion.identity);
            fx.SetParent(_tPP);

            StartCoroutine(DFX(fx));
            _rCA.SetTrigger(CI);
        }
    }

    private IEnumerator DFX(Transform fx)
    {
        yield return new WaitForSeconds(1);
        Destroy(fx.gameObject);
    }
}
