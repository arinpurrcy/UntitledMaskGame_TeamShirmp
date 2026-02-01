using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PasswordSystem : MonoBehaviour
{
    //This does need the player capsule thing cause that has the rep script that this calls from
    //Just some stuff we can adjust in Unity
    [Header("InGame Stuff")]
    public KeyCode[] _inputs = { KeyCode.A, KeyCode.B, KeyCode.C, KeyCode.D };
    public float _inputDelay = 0.5f;
    public int _sequenceLength = 4;
    public GameObject player;
    private ReputationSystem _rep;
    public bool _canPause;

    //The text objects, which will change throughout the thing.
    public TextMeshProUGUI _sequenceText;
    public TextMeshProUGUI _displayText;

    //THe privates for the in game stuff
    private bool _isTurn = false;
    private int _playerIndex = 0;
    private List<KeyCode> _sequence = new List<KeyCode>();
    private float _sequenceDisplaySpeed = 2f;

    private void Start()
    {
        //This just sets it to nothing at the start
        _sequenceText.text = "";

        _rep = player.GetComponent<ReputationSystem>();

        RegenerateSequence();

        _canPause = false;
    }

    //Will make a random Sequence
    void GenerateSequence()
    {
        _sequence.Clear();
        for (int i = 0; i < _sequenceLength; i++)
        {
            _sequence.Add(_inputs[Random.Range(0, _inputs.Length)]);
        }
    }

    //Shows said sequence that was made. 
    IEnumerator ShowSequence()
    {
        _isTurn = false;
        _playerIndex = 0;

        _displayText.text = "Follow the sequence, it will show up one at a time";

        yield return new WaitForSeconds(1f);

        Debug.Log(_sequenceDisplaySpeed);
        foreach (KeyCode key in _sequence)
        {
            _sequenceText.text = $"{key}";
            Debug.Log(key);
            yield return new WaitForSeconds(_sequenceDisplaySpeed);
            _sequenceText.text = " ";
            yield return new WaitForSeconds(0.1f);
        }
        _sequenceText.text = "";
        _displayText.text = "Now it's your turn!";
        _isTurn = true;
    }

    //Will check if it is the player's turn, and if so will do stuff. 
    private void Update()
    {
        if (!_isTurn)
        {
            return;
        }

        //Checks if the player has inputed the inputs.
        //Will not accept any key that isn't apart of the _inputs
        foreach (KeyCode key in _inputs)
        {
            if (Input.GetKeyDown(key))
            {
                CheckPlayerInput(key);
                break;
            }
        }
    }

    //This checks if the inputted key is correct. If it is, then it continues
    //If not, then it just ends
    void CheckPlayerInput(KeyCode key)
    {
        if (key == _sequence[_playerIndex])
        {
            _playerIndex++;
            _sequenceText.text += $"{key}, ";
            if (_playerIndex >= _sequence.Count)
            {
                new WaitForSeconds(1f);
                _displayText.text = "Correct!";
                Debug.Log("Player completed the sequence!");
                _rep.HealRepuation();
                _isTurn = false;

            }
        }
        else
        {
            _sequence.Clear();
            Debug.Log("no");
            _displayText.text = "Uncorrect!";
            _isTurn = false;
            _rep.DamageRepuatation();
            if(_rep._currentReputation > -1)
            {
                RegenerateSequence();
            }
            
            
        }
    }

    //make a whole new sequence
    void RegenerateSequence()
    {
        SequenceSpeed();
        GenerateSequence();
        StartCoroutine(ShowSequence());
    }

    //changes speed depending on how low your rep is
    void SequenceSpeed()
    {
        _sequenceDisplaySpeed /= 1.5f;
         
         if (_rep._currentReputation == 4)
        {
            _sequenceDisplaySpeed = 2f;
            _sequenceDisplaySpeed /= 2.5f;
            return;
        }
        else if (_rep._currentReputation == 3)
        {
            _sequenceDisplaySpeed = 2f;
            _sequenceDisplaySpeed /= 3.5f;
            return;
        }
        else if (_rep._currentReputation == 2)
        {
            _sequenceDisplaySpeed = 2f;
            _sequenceDisplaySpeed /= 4.5f;
            return;
        }
        else if (_rep._currentReputation == 1)
        {
            _sequenceDisplaySpeed = 2f;
            _sequenceDisplaySpeed /= 5.5f;
            return;
        }
        else
        {
            _sequenceDisplaySpeed /= 1f;
            return;
        }

    }

}
