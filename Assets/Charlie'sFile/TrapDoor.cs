using UnityEngine;

public class TrapDoor : MonoBehaviour
{
    //Pull the Object with the animator to this script. Not the empty parent object
    public GameObject _trapDoor;
    private Animator _trapDoorAnimator;

    //This just pulls the animator off of the trap door. 
    void Start()
    {
        _trapDoorAnimator = _trapDoor.GetComponent<Animator>();
    }

    //This will set the "triggers" to switch the animations for both entering and exiting the Trigger. I have tested it, it works. 
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _trapDoorAnimator.ResetTrigger("TrapDoorClose");
            _trapDoorAnimator.SetTrigger("TrapDoorOpen");

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _trapDoorAnimator.ResetTrigger("TrapDoorOpen");
            _trapDoorAnimator.SetTrigger("TrapDoorClose");
        }
    }
}
