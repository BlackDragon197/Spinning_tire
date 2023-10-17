
using UnityEngine;

public class UIActions : MonoBehaviour
{
    public void BackToMainMenu()
    {
        
        UIManager.Instance.SelectMainMenu();
    }

    public void ReturnToMainMenu()
    {
        AdManager.Instance.ShowInterstitialAd();
    

    }

    public void PauseGame()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.GameStates.PAUSE);
    }

    public void ResumeGame()
    {
        GameStateManager.Instance.ChangeState(GameStateManager.GameStates.INGAME);
    }
    public void RestartGame()
    {
        SceneLoader.Instance.ReloadLevel();
    }
}
