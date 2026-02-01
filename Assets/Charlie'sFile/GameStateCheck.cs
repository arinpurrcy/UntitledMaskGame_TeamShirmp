using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStateCheck : MonoBehaviour
{
    //This script will check the state of the game, for if it should run
    //A scene for Game Over

    //This is going to check the things with the player as both scripts
    //Will be attached, but each have seperate things
    public GameObject _player;
    private ParkourLivesScript _parkour;
    private ReputationSystem _reputation;

    //This just gets the components for both so I can grab the varibles
    private void Start()
    {
        _parkour = _player.GetComponent<ParkourLivesScript>();
        _reputation = _player.GetComponent<ReputationSystem>();
    }

    //This will constantly check if those bools are true, but they are set
    //To false at the start
    private void Update()
    {
        if(_parkour._isDead == true)
        {
            //Respawn at start of level
            _parkour.ResetHealth();
            _parkour._isDead = false;
        }

        if(_reputation._isDepised == true)
        {
            SceneManager.LoadScene(5);
            //Replace scene 5 with whatever scene the game over ends up being
        }
    }
}
