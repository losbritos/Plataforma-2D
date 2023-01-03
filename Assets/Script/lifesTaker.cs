using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifesTaker : MonoBehaviour
{
    public int damage;
    public bool ignoreInvicible;
    public string target = "Player";


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == target)
        {
            collision.GetComponent<lifecontroller>().Damage(damage,ignoreInvicible);
        }
    }
}
