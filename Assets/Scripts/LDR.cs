using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LDR : MonoBehaviour
{
    private float _lT;

    [SerializeField] private TextMeshProUGUI _lTT;

    private void Start()
    {
        _lT = Random.Range(3, 6);
        StartCoroutine(FL());
    }

    private System.Collections.IEnumerator FL()
    {
        float startTime = Time.time;

        while (Time.time - startTime < _lT)
        {
            float progress = (Time.time - startTime) / _lT * 100f;

            _lTT.text = Mathf.RoundToInt(progress) + " %";

            yield return null;
        }

        SceneManager.LoadScene(1);
    }
}
