using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupSystem : MonoBehaviour
{
    [SerializeField] GameObject playerObject;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Chicken")
        {
            Destroy(collision.gameObject);
            playerObject.GetComponent<PlayerHealth>().Heal(20);
        }
        else if (collision.tag =="Experience")
        {
            Destroy(collision.gameObject);
            playerObject.GetComponent<LevelSystem>().currentXp++;
        }
    }
}
