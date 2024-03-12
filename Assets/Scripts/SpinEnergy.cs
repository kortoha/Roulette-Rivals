using TMPro;
using UnityEngine;

public class SpinEnergy : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _goldChipCountText;
    [SerializeField] private int _goldChipCount;

    private int _maxGoldChipCount;

    private void Start()
    {
        _maxGoldChipCount = _goldChipCount;
    }

    private void Update()
    {
        _goldChipCountText.text = _goldChipCount.ToString() + "/" + _maxGoldChipCount.ToString();
    }
     
    public void UseEnergyForGoldChip()
    {
        _goldChipCount--;
    }

    public int GetGoldChipCount()
    {
        return _goldChipCount;
    }

    public void BuyGoldChip()
    {
        if(_goldChipCount < _maxGoldChipCount)
        {
            _goldChipCount++;
        }
    }
}
