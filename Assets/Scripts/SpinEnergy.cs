using System;
using TMPro;
using UnityEngine;

public class SpinEnergy : MonoBehaviour
{
    public static SpinEnergy Instance { get; private set; }

    [NonSerialized] public bool iMO = false;

    [SerializeField] private TextMeshProUGUI _gCCT;
    [SerializeField] private int _gCC;
    [SerializeField] GameObject _mG;
    [SerializeField] GameObject _fWP;
    [SerializeField] GameObject _tP;
    [SerializeField] GameObject _tTB;

    private int _mGCC;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _mGCC = _gCC;
    }

    private void Update()
    {
        _gCCT.text = _gCC.ToString() + "/" + _mGCC.ToString();

        if(_gCC == 0 && !iMO)
        {
            iMO = true;
            Invoke("IOMG", 1.5f);
        }
    }
     
    public void UEFGC()
    {
        _gCC--;
    }

    public int GGCC()
    {
        return _gCC;
    }

    public void BGC()
    {
        if(_gCC < _mGCC)
        {
            _gCC++;
        }
    }

    public void WGC(int a)
    {
        _gCC += a;
        if(_gCC > _mGCC)
        {
            _gCC = _mGCC;
        }
    }

    void OMG()
    {
        _mG.SetActive(true);
        MiniGameInput.Instance.iW = false;
        _fWP.SetActive(false);
        _tP.SetActive(false);
        _tTB.SetActive(false);
    }

    void IOMG()
    {
        Fader.Instance.PFA();
        Invoke("OMG", 0.51f);
    }
}
