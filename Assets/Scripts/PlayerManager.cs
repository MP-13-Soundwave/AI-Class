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
       
    }

    public void EnergonCubes()
    {
        //Heal(20f);
        StartCoroutine(HealOverTime(3, 1f));
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
                yield return new WaitForSeconds(waitTime);
            }

            _isHealOverTimeRunning = false;
        }
        
    }

    public void Retreat()
    {
        DealDamage(25f);
    }

    public void EnergonShield()
    {

    }

    public void PlasmaCannon()
    {
        _aiManager.DealDamage(15f);
    }
}
