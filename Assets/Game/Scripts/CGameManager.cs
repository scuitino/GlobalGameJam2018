using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CGameManager : MonoBehaviour {

    #region SINGLETON PATTERN
    public static CGameManager instance = null; //static - the same variable is shared by all instances of the class that are created, and can be private, protected or public.
    #endregion

    private void Awake()
    {
        //Check if instance already exists
        if (instance == null)

            //if not, set instance to this
            instance = this;

        //If instance already exists and it's not this:
        else if (instance != this)

            //Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a CLoadListData
            Destroy(gameObject);
    }


    public enum State
    {
        PLAYING,
        PAUSED
    }

    public State _state;

    // time per round
    [SerializeField]
    int _matchTime;

    // game time
    float _timer;

    [SerializeField]
    float _timerSpeed;

    [SerializeField]
    List<CHuman> _humans;

    [SerializeField]
    Text _timerText;

    int _player1Score, _player2Score;

    [SerializeField]
    GameObject _victoryP1, _victoryP2, _draw;

    [SerializeField]
    GameObject _GO;
    
    public AudioSource _guitarSound, _violinSound, _attackSound;

    private void OnEnable()
    {
        _state = State.PAUSED;
    }

    private void FixedUpdate()
    {
        if (_state == State.PAUSED)
        {

        }
        else if (_state == State.PLAYING)
        {
            _timer -= Time.deltaTime;
            if (_timer < 0)
            {
                SetState(State.PAUSED);
            }
        }
        _timerText.text = Mathf.Ceil(_timer).ToString();
    }

    public void SetState(State pState)
    {
        _state = pState;
        if (_state == State.PAUSED)
        {
            EndGame();
            _timer = 0;
        }
        else if (_state == State.PLAYING)
        {
            
        }
    }

    public IEnumerator StartMatch()
    {
        _timer = _matchTime;
        _player1Score = 0;
        _player2Score = 0;
        _GO.SetActive(true);
        yield return new WaitForSeconds(4);
        SetState(State.PLAYING);
    }

    public void EndGame()
    {
        for (int i = 0; i < _humans.Count; i++)
        {
            if (_humans[i].GetGod() == 1)
                _player1Score++;

            if (_humans[i].GetGod() == 2)
            {
                _player2Score++;
            }
        }
        if (_player1Score > _player2Score)
        {
            _victoryP1.SetActive(true);
        }
        else if (_player1Score < _player2Score)
        {
            _victoryP2.SetActive(true);
        }
        else
        {
            _draw.SetActive(true);
        }

    }
}
