using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    public GameObject target;
    public float movingSpeed;
    public int damage;

    private Rigidbody2D rig;

    void Start() {
        if (movingSpeed <= 0.01f) {
            movingSpeed = 0.01f;
        }
        if (target == null) {
            Destroy(gameObject);
            return;
        }
        rig = gameObject.GetComponent(typeof(Rigidbody2D)) as Rigidbody2D;
        rig.AddForce((target.transform.position - this.transform.position).normalized * movingSpeed);
    }

    void Update() {
        if (target == null) {
            Destroy(gameObject);
            //如果超过容器的范围就会把自己销毁掉
        }
    }
}
