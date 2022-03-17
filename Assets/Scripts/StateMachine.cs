using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public float chaseDistance = 3;
    //an array of GameObjets
    public Transform[] waypoints;
    public int waypointIndex = 0;
    public float speed = 1.5f;
    public float minGoalDistance = 0.05f;

    //comma spepareting a list of identifiers
    public enum State
    {
        Attack,
        Defence,
        RunAway,
        BerryPicking
    }

    public State currentState;
    public AIMovement aiMovement;

    private void Start()
    {
        aiMovement = GetComponent<AIMovement>();

        NextState();    
    }

    private void NextState()
    {
        //runs one of the cases that matched the value (in this example the value is currentState)
        switch (currentState)
        {
            case State.Attack:
                StartCoroutine(AttackState());
                break;
            case State.Defence:
                StartCoroutine(DefenceState());
                break;
            case State.RunAway:
                StartCoroutine(RunAwayState());
                break;
            case State.BerryPicking:
                StartCoroutine(BerryPickingState());
                break;
        }         
    }

    //Coroutine is a speical method that can be paused and returned to later
    private IEnumerator AttackState()
    {
        Debug.Log("Enter Attack Mode");
        //yield return pauses running of our coroutine
        while (currentState == State.Attack)
        {
            Debug.Log("Attacking");
            aiMovement.AIMoveTowards(aiMovement.player);

            if (Vector2.Distance(transform.position, aiMovement.player.position) > aiMovement.chaseDistance)
            {
                currentState = State.BerryPicking;
            }

            yield return null; //return to method on the very next frame
        }
        Debug.Log("Exit Attack Mode");
        NextState();
    }

    private IEnumerator DefenceState()
    {
        Debug.Log("Enter Defence Mode");
        while (currentState == State.Defence)
        {
            Debug.Log("Defending");
            yield return null; 
        }
        Debug.Log("Exit Defence Mode");
        NextState();
    }

    private IEnumerator RunAwayState()
    {
        Debug.Log("Strategic Withdraw");
        while (currentState == State.RunAway)
        {
            Debug.Log("Running Away");
            yield return null; 
        }
        Debug.Log("Making a Stance");
        NextState();
    }

    private IEnumerator BerryPickingState()
    {
        Debug.Log("Enter Regeneration Mode");

        aiMovement.LowestDistance();

        //runs once every frame
        //sounds like our update
        while (currentState == State.BerryPicking)
        {
            Debug.Log("Healing");
            aiMovement.WaypointUpdate();
            aiMovement.AIMoveTowards(aiMovement.waypoints[aiMovement.waypointIndex]);

            //chase player if close enough
            if (Vector2.Distance(transform.position, aiMovement.player.position) < aiMovement.chaseDistance)
            {
                currentState = State.Attack;
            }



            yield return null; 
        }
        Debug.Log("Exit Regeneration Mode");
        NextState();
    }
}
