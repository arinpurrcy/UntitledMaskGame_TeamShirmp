using UnityEngine;

public class CharliesNotes : MonoBehaviour
{
    /*
     This is just one big Notes thing for things you should take into account when importing this.

    On Player: 
    - Reputation System
    - Parkour Lives Script
    - Probably also GameCheckState unless we have something Globally loaded throughout all scenes
    - Mask Swap Probably as well, unless again we have something Globally loaded

    Not on Player:
    - Spring: For obvious reasons put it on the spring, will require the player caspule to get the jump force
    - Password System: Though that should already be tied to the SimonSays thing. It does require the Player Caspule to get the rep script
    - Game Over Buttons: Will be tied to the scene with the game Over section

    You can edit the Repuatation sprite thing, just make sure you do it for all, (or ask me to) so we can edit it for all the sprites for the masks. Just make sure it's the same across the board

    To change the Keycode for it, do it within Unity itself

    We might have to figure out how to lock player movement for the minigame itself, and have a check to see if it's been played before so if you accidently leave you don't have to replay it.

    also could some of these have been combined, sure. But did I write them like that? No. and I don't feel like potentially breaking everything, 

    Animation: 
    For the Trap Door, you have to add both a paramater for both opening and closing, and a transition from one to the other and vice versa. 
    Make Trap Door an empty object, the trigger a child of it, and the trap door itself with the animation also a child of the empty object, so both the 
    Trap Door and Trigger are together

    Animations:
    If you change the trigger names, change them within the script as well
    If you make one first, and want to set the other one to be default, left click on the Entry and hit "Make default" or somehting like that

    Make transistions between the two animation, and set the conditions to be the Parameters you named. 
     */
}
