using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform[] _sPA;
    public GameObject[] _cA;

    private float _t = 0f;
    private float _sI = 1f;

    private void Update()
    {
        _t += Time.deltaTime;

        if (_t >= _sI && !MiniGameInput.Instance.iW)
        {
            _t = 0f;

            float spawnChance = Random.value;
            int objectIndex;

            if (spawnChance < 0.5f)
            {
                objectIndex = 0;
            }
            else
            {
                objectIndex = Random.Range(1, _cA.Length);
            }

            int spawnPointIndex = Mathf.FloorToInt(Random.value * _sPA.Length);

            Instantiate(_cA[objectIndex], _sPA[spawnPointIndex].position, Quaternion.identity);
            _sI = Random.Range(0.3f, 0.7f);
        }
    }
}
