using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame_Script : MonoBehaviour
{
    public void StartGame()
    {
        //Change to first level name when Level One is finished
        //SceneManager.LoadScene("SceneName"); 

        SceneManager.LoadScene("Taylor_Scene");

        //Delete when scene is ready
        Debug.Log("Game has started");
    }
}
