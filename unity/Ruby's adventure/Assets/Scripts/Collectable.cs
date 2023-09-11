using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public ParticleSystem CollectEffect;
    public AudioClip collectClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        PlayerController pc = other.GetComponent<PlayerController>();
        if (pc != null) {
            Debug.Log("玩家碰到草莓");
            if (pc.myCurrentHealth() < pc.myMaxHealth()) {
                pc.changeHealth(1);
                // Instantiate(CollectEffect, transform.position, Quaternion.identity);
                Destroy(this.gameObject);
                AudioManager.instance.AudioPlay(collectClip);
            }
        }    
    }
}
