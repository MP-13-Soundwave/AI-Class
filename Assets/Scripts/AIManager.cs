using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIManager : BaseManager
{
   public enum State
    {
        FullHP,
        LowHP,
        Dead
    }

    public State currentState;
    protected PlayerManager _playerManager;
    [SerializeField] protected Animator _anim;
    protected override void Start()
    {
        _playerManager = GetComponent<PlayerManager>();
        if (_playerManager == null)
        {
            Debug.LogError("PlayerManager not found");
        }
    }
    public override void TakeTurn()
    {
        switch (currentState)
        {
            case State.FullHP:
                FullHPState();
                break;
            case State.LowHP:
                LowHPState();
                break;
            case State.Dead:
                DeadState();
                break;
        }

        StartCoroutine(EndTurn());
    }

    IEnumerator EndTurn()
    {
        yield return new WaitForSecondsRealtime(2f);
        _playerManager.TakeTurn();
    }

    void DeadState()
    {
        Debug.Log("Victory");
    }

    void LowHPState()
    {
        int randomAttack = Random.Range(0, 10);

        switch (randomAttack)
        {
            case int i when i > 0 && i <= 2:
                EnergonCubes();
                break;
            case int i when i > 2 && i <= 3:
                Retreat();
                break;
            case int i when i > 8 && i <= 9:
                JetLazer();
                break;
        }
    }

    void FullHPState()
    {
        int randomAttack = Random.Range(0, 10);

        if (_health < 40f)
        {
            currentState = State.LowHP;
        }

        switch (randomAttack)
        {
            case int i when i > 0 && i <= 2:
                JetLazer();
                break;
            case int i when i > 2 && i <= 3:
                EnergonShield();
                break;
            case int i when i > 8 && i <= 9:
                Retreat();
                break;
        }
    }

    public void EnergonCubes()
    {
        Heal(20f);
        Debug.Log("EnergonCubes");
    }

    public void Retreat()
    {
        DealDamage(25f);
        Debug.Log("Retreat");
    }

    public void EnergonShield()
    {
        Debug.Log("EnergonShield");
    }

    public void JetLazer()
    {
        _playerManager.DealDamage(12f);
        _anim.SetTrigger("JetLazer");
        Debug.Log("JetLazer");
    }
}
