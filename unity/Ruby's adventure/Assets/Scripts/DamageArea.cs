using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageArea : MonoBehaviour
{
    void OnTriggerStay2D(Collider2D other) {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null) {
            pc.changeHealth(-1);
            // Debug.Log(pc.myCurrentHealth() + "" + pc.myCurrentHealth());
            if (pc.myCurrentHealth() == 0) {
                Destroy(pc.gameObject);
            }
        }
    }
}
