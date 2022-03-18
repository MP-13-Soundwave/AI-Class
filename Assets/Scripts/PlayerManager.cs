using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : BaseManager
{
    private AIManager _aiManager;
    [SerializeField] protected CanvasGroup _buttonGroup;

    protected override void Start()
    {
        base.Start();

        _aiManager = GetComponent<AIManager>();
        if (_aiManager == null)
        {
            Debug.LogError("AIManager not found");
        }
    }
    public override void TakeTurn()
    {
        _buttonGroup.interactable = true;
    }

    public void EndTurn()
    {
        _buttonGroup.interactable = false;
        _aiManager.TakeTurn();
    }

    public void EnergonCubes()
    {
        //Heal(20f);
        StartCoroutine(HealOverTime(3, 1f));
        EndTurn();
    }

    private bool _isHealOverTimeRunning = false;
    private IEnumerator HealOverTime(int times, float waitTime)
    {
        if (_isHealOverTimeRunning == false)
        {
            _isHealOverTimeRunning = true;
            for (int i = 0; i < 3; i++)
            {
                Heal(10f);
                yield return new WaitForSecondsRealtime(waitTime);
            }

            _isHealOverTimeRunning = false;
        }
        
    }

    public void Retreat()
    {
        DealDamage(25f);
        EndTurn();
    }

    public void EnergonShield()
    {
        EndTurn();
    }

    public void PlasmaCannon()
    {
        _aiManager.DealDamage(15f);
        EndTurn();
    }
}
