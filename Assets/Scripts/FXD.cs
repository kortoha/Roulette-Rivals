using UnityEngine;

public class FXD : MonoBehaviour
{
    private void Update()
    {
        if(Time.timeScale == 0)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }
}
