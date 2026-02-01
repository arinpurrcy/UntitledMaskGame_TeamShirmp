using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverButtons : MonoBehaviour
{

    //This one connects to the GameOver prefabs, but because we don't have a checkpoint thing yet I haven't coded it in
    public void OnRetryButton()
    {

    }

    //Sends you back to the main menu
    public void OnMainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
