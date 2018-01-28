using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CGameManager : MonoBehaviour {

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

    int _player1Score, _player2Score;

    private void OnEnable()
    {
        _state = State.PAUSED;
    }

    private void FixedUpdate()
    {
        if (_state == State.PAUSED)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                StartMatch();
            }
        }
        else if (_state == State.PLAYING)
        {
            _timer -= Time.deltaTime;
            Debug.Log(_timer);
            if (_timer < 0)
            {
                SetState(State.PAUSED);
            }
        }
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

    public void StartMatch()
    {
        _timer = _matchTime;
        _player1Score = 0;
        _player2Score = 0;
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
            Debug.Log(_player1Score + "Win");
        }
        else if (_player1Score < _player2Score)
        {
            Debug.Log(_player2Score + "Win");
        }
        else
        {
            Debug.Log("Draw");
        }

    }
}
