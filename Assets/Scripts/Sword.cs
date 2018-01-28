using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour {

    public AudioClip swordHitGround;
    public AudioClip swordHitEnemy;
    public float speed = 5.0f;
    private bool shooting = false;
    private bool ready = false;
    private Vector3 target;
    private int damage = 1;
	public GameObject sparkFx;


    private void Awake() {
        GetComponent<Collider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void Initialize(float summonTime) {
        Invoke("PlaySummonAnim", summonTime - 0.27f);
        Invoke("SetReady", summonTime);
    }

    private void PlaySummonAnim() {
        GetComponent<Animator>().SetTrigger("Summon");
    }

    private void SetReady() {
        GetComponent<SpriteRenderer>().enabled = true;
        ready = true;
    }

    public void Shoot(Vector3 position) {
        shooting = true;
        GetComponent<Collider2D>().enabled = true;
        target = position;
    }

    private void Update() {
        if (shooting) {
            LookAtTarget();
            MoveTowardsTarget();
        }

        if (Vector3.Distance(transform.position, target) < 0.001 && shooting) {
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
                collision.gameObject.GetComponent<IDamageTaker>().TakeDamage(damage);
				var spark = Instantiate (sparkFx, collision.gameObject.transform.position, transform.rotation);
				spark.transform.parent = null;
                SoundManager.instance.PlayEffect(swordHitEnemy);
            }
        }
    }

    private void ClipHalf() {
        SoundManager.instance.PlayEffect(swordHitGround);
        GetComponent<SpriteRenderer>().sortingLayerName = "Background";
        GetComponent<Animator>().SetTrigger("Stick");
        gameObject.AddComponent<FadeoutObject>();
    }

    public bool Ready {
        get { return ready; }
    }
}
