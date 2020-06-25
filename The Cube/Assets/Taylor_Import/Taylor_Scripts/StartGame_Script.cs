using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame_Script : MonoBehaviour
{
    public void StartGame()
    {
        //Change to first level name when Level One is finished
        //SceneManager.LoadScene("SceneName"); 
        SoundManager.PlaySound(SoundManager.Sound.UIClick);
        SceneManager.LoadScene("Taylor_Level");

        //Delete when scene is ready
        Debug.Log("Game has started");
    }
}
