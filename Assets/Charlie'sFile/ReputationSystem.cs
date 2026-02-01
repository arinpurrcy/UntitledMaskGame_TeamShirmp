using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ReputationSystem : MonoBehaviour
{
    //I attached this to the player capsule model thing, and not the canvas
    //We can change max rep in game
    public int _currentReputation;
    public int _maxReputation;
    public bool _isDepised = false;

    //This will have it cycle through the sprites
    //MAKE SURE all sprites are set as "Single" in Sprite mode, otherwise Unity won't accept it,
    public Sprite[] _healthSprites;
    private Sprite _currentRepSprite;

    //This is to display the sprites
    public Image _image;

    //So it sets it at the beginning
    private void Start()
    {
        _currentReputation = _maxReputation;
    }


    //This will change the sprites
    private void Update()
    {
        ChangeSprite();

        //and check if you failed too much
        if (_currentReputation <= 0)
        {
            _isDepised = true;
        }
    }

    //Simple Heal Method
    public void HealRepuation()
    {
        if (_currentReputation < _maxReputation)
        {
            _currentReputation++;

        }

    }

    //Simple TakeDamage Method
    public void DamageRepuatation()
    {
        if (_currentReputation > 0)
        {
            _currentReputation--;
        }
    }

    

    //This just sets the array's current sprite for it to change within game
    public Sprite SpriteChanges()
    {
        Sprite _setSprite;
        if (_currentReputation == _maxReputation)
        {
            _setSprite = _healthSprites[0];
        }
        else if (_currentReputation == 4)
        {
            _setSprite = _healthSprites[1];

        }
        else if (_currentReputation == 3)
        {
            _setSprite = _healthSprites[2];
        }
        else if (_currentReputation == 2)
        {
            _setSprite = _healthSprites[3];
        }
        else if (_currentReputation == 1)
        {
            _setSprite = _healthSprites[4];
        }
        else
        {
            _setSprite = _healthSprites[4];
        }

        _currentRepSprite = _setSprite;

        return _currentRepSprite;


    }

    //This literally just changes the sprite it is not that special, could have this been in update Sure butttttt who cares
    public void ChangeSprite()
    {
        SpriteChanges();
        _image.sprite = _currentRepSprite;

    }
}
