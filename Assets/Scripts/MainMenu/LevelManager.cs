using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; } 

    public LevelButton[] lA;

    private void OnEnable()
    {
        Instance = this;
        IL();
    }

    private void IL() 
    {
        for (int i = 0; i < lA.Length; i++)
        {
            lA[i].buttonID = i; 
            bool isOpened = PlayerPrefs.GetInt("Level_" + i + "_IsOpened", 0) == 1;
            lA[i].SetState(isOpened); 
        }
    }

    public void SLS(int bID, bool isOpened) 
    {
        PlayerPrefs.SetInt("Level_" + bID + "_IsOpened", isOpened ? 1 : 0);
        PlayerPrefs.Save();
    }

    public void SLES(int bID, bool isOpened) 
    {
        if (bID >= 0 && bID < lA.Length)
        {
            lA[bID].SetState(isOpened); 
            SLS(bID, isOpened); 
            lA[bID].UpdateButtonVisual(); 
        }
        else
        {
            Debug.LogError("Invalid button ID.");
        }
    }
}
