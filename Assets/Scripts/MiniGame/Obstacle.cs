using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField] GameObject _fX;

    private void Update()
    {
        if (MiniGameInput.Instance.iW)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer != LayerMask.NameToLayer("Braker"))
        {
            Destroy(collision.gameObject);
            GameObject fx = Instantiate(_fX, gameObject.transform.position, Quaternion.identity);
            MGFXD.Instance.ATFXA(fx);
            fx.transform.SetParent(MGFXD.Instance.transform);
            Destroy(gameObject);
        }
        else
        {
            GameObject fx = Instantiate(_fX, gameObject.transform.position, Quaternion.identity);
            MGFXD.Instance.ATFXA(fx);
            fx.transform.SetParent(MGFXD.Instance.transform);
            Destroy(gameObject);
        }
    }
}
