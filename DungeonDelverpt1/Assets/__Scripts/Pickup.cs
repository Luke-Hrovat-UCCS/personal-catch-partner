using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject go = other.gameObject;
        if(go.GetComponent<Dray>() != null )
        {
            go.GetComponent<Dray>().Upgrade();
            Destroy(gameObject);
        }
    }
}
