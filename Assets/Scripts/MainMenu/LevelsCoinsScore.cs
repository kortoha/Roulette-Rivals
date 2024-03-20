using TMPro;
using UnityEngine;

public class LevelsCoinsScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _coinsScoreText;

    private void Update()
    {
        _coinsScoreText.text = MoneyManager.Instance.GC().ToString();
    }
}
