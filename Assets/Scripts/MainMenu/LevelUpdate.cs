using TMPro;
using UnityEngine;

public class LevelUpdate : MonoBehaviour
{
    [SerializeField] private LevelButton[] _lB; 
    private int bP = 300; 

    private void OnEnable()
    {
        SNOL();
        SPOLOL();
    }

    private void SNOL() 
    {
        for (int i = 0; i < _lB.Length; i++)
        {
            int id = i + 1;
            GBT(_lB[i], id);
        }
    }

    private void GBT(LevelButton btn, int id) 
    {
        TextMeshProUGUI btnsText = btn.GetComponentInChildren<TextMeshProUGUI>();

        if (btnsText != null)
        {
            btnsText.text = id.ToString();
        }
    }

    private void SPOLOL() 
    {
        for (int i = 0; i < _lB.Length; i++)
        {
            int price = bP + i * 100;
            _lB[i].openPrice = price;
        }
    }
}
