using UnityEngine;

public class D : MonoBehaviour
{
    [SerializeField] float _t;

    private void Update()
    {
        if (MiniGameInput.Instance.iW)
        {
            Destroy(gameObject);
        }
    }
    private void OnEnable()
    {
        Invoke("DS", _t);
    }

    void DS()
    {
        Destroy(gameObject);
    }
}
