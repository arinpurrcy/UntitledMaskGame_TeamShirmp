using UnityEngine;

public class Spring : MonoBehaviour
{
    //Pull Player onto this spot
    public Rigidbody _player;
    
    //MAKE SURE to change this within the editor, it is set to 0 by default
    public float _bounceForce;
    public AudioSource _bounceSource;
    public AudioClip _bounceSoundEffect;

    //Pushes the player based on how they enter
    public void OnTriggerEnter(Collider collider)
    {
        
        Vector3 _pushDirection = -_player.linearVelocity.normalized;
        _player.AddForce(_pushDirection * _bounceForce, ForceMode.Impulse);
    }
}
