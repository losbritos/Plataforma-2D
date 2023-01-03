using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifecontroller : MonoBehaviour
{
    public int lifes_current;
    public int lifes_max;
    public float invencible_time;
    bool invencible;

    // Start is called before the first frame update
    void Start()
    {
        lifes_current = lifes_max;
    }

    public enum DeathMode { Teleport,ReloadScene,Destroy}
    public DeathMode death_mode;
    public Transform respawn;
    public void Damage(int damage = 1, bool ignoreInvecible = false)
    {
        if (!invencible || ignoreInvecible)
        {
            lifes_current -= damage;
            StartCoroutine(Invencible_Corutine());
            if (lifes_current > 0)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        switch (death_mode)
        {
            case DeathMode.Teleport:
                transform.position = respawn.position;
                lifes_current = lifes_max;
                break;
            case DeathMode.ReloadScene:
                break;
            case DeathMode.Destroy:
                Destroy(gameObject);
                break;
            default:
                break;
        }

    }

    IEnumerator Invencible_Corutine()
    {
        invencible = true;
        yield return new WaitForSeconds(invencible_time);
        invencible = false;
    }
}   
