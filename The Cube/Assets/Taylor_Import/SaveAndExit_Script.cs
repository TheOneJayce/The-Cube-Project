using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveAndExit_Script : MonoBehaviour
{
    public void SaveAndExit()
    {

        //Here, we should place a way for the system to save the players progress


        //When the StartMenu is in the build scene, this will function properly
        //SceneManager.LoadScene("StartMenu");

        //Delete when scene is ready
        Debug.Log("Player's progress is saved and they are returning too the Start Menu");

    }
}
