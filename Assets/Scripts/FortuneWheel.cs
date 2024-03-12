using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;

public class FortuneWheel : MonoBehaviour
{
    public static FortuneWheel Instance { get; private set; }

    [NonSerialized] public bool isSF = true; 
    [SerializeField] private SpinEnergy _sE;
    [SerializeField] private AudioSource _sSFX;

    public Transform w;
    public Button sB; 

    private float _sS;
    private bool _iCS = true; 

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        sB.onClick.AddListener(() =>
        {
            SS();
        });
    }

    private void SS() 
    {
        isSF = false;

        if (_sE.GetGoldChipCount() > 0)
        {
            if (_iCS)
            {
                WheelIndicator.Instance.isWinOnse = false;
                StartCoroutine(S());
                _iCS = false;
            }
        }
    }

    private IEnumerator S() 
    {
        if (_sE.GetGoldChipCount() > 0)
        {
            _sS = UnityEngine.Random.Range(200, 400);
            _sSFX.Play();
            while (_sS > 0)
            {
                w.Rotate(Vector3.forward * _sS * Time.deltaTime * 2);
                _sS -= Time.deltaTime * 60;
                yield return null;
                if (_sS <= 0)
                {
                    _sE.UseEnergyForGoldChip();
                    _iCS = true;
                    _sSFX.Stop();
                }
            }
        }
    }

    public bool ICS()
    {
        return _iCS;
    }
}
