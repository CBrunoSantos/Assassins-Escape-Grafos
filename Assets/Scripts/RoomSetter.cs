using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSetter : MonoBehaviour
{
    public int id;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) {
            other.GetComponent<Linus>().playerPosition = id;
        }
        if (other.CompareTag("Monster"))
        {
            other.GetComponent<Murder>().murderLocation = id;
        }
    }
}
