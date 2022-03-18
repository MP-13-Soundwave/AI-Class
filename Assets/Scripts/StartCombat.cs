using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCombat : MonoBehaviour
{
    [SerializeField] GameObject _combatCanvas;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        AIMovement aiMove = collision.collider.gameObject.GetComponent<AIMovement>();

        if (aiMove == null)
        {
            return;
        }

        Debug.LogWarning("WE HAVE HIT AN AI");
        //Entered Combat
        _combatCanvas.SetActive(true);

        Time.timeScale = 0;
        //Time.timeScale = 1; (Play Game)
    }


}
