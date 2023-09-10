using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    Rigidbody2D rbody;
    public Vector2 position;
    // Start is called before the first frame update
    void Awake() {
        rbody = GetComponent<Rigidbody2D>();
        Destroy(this.gameObject, 2f);
    }

    void start()
    {
        transform.position = position;
    }
    // // Update is called once per frame
    // void Update()
    // {
        
    // }
    public void Move(Vector2 moveDirection, float moveForce) {
        rbody.AddForce(moveDirection * moveForce * 10);
    }

    void OnCollisionEnter2D(Collision2D other) {
        EnemyController ec = other.gameObject.GetComponent<EnemyController>();
        if (ec != null) {
            // Debug.Log("击中敌人");
            ec.Fixed();
        }
        Destroy(this.gameObject);
    }
}
