using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {
    
    public float speed = 5.0f;
    private bool shooting = false;
    private bool ready = false;
    private Vector3 target;
    private int damage = 1;


    private void Start() {
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Initialize(float summonTime) {
        GetComponent<Animator>().SetTrigger("Summon");
        GetComponent<Animator>().SetFloat("ReverseSummonSpeed", 1 / summonTime);
        Invoke("SetReady", summonTime);
    }

    private void SetReady() {
        GetComponent<SpriteRenderer>().enabled = true;
        ready = true;
    }

    public void Shoot(Vector3 position) {
        shooting = true;
        target = position;
    }

    private void Update() {
        if (shooting) {
            LookAtTarget();
            MoveTowardsTarget();
        }

        if (Vector3.Distance(transform.position, target) < 0.001) {
            shooting = false;
            ClipHalf();
        }
    }

    private void LookAtTarget() {
        Vector3 diff = Vector3.Normalize(target - transform.position);
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z + 90);
    }

    private void MoveTowardsTarget() {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, step);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (shooting) {
            if (collision.gameObject.tag == "Enemy") {
                Debug.Log("Hit the enemy");
                collision.gameObject.GetComponent<IDamageTaker>().TakeDamage(damage);
            }
        }
    }

    private void ClipHalf() {
        GetComponent<SpriteRenderer>().sortingLayerName = "Background";
        GetComponent<Animator>().SetTrigger("Stick");
    }

    public bool Ready {
        get { return ready; }
    }
}
