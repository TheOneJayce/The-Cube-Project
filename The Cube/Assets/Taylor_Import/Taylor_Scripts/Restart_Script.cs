using UnityEngine;
using UnityEngine.SceneManagement;

public class Restart_Script : MonoBehaviour
{
    public void RestartLevel()
    {
        // This should work properly once the scenes are in the build settings
        /*Scene loadedLevel = SceneManager.GetActiveScene();
        SceneManager.LoadScene(loadedLevel.buildIndex);*/

        //Delete when scene is ready
        Debug.Log("Player has restarted their current level");
    }
}
