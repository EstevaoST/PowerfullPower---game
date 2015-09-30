using UnityEngine;
using System.Collections;

public class MutableShooter : MonoBehaviour
{

    public Stats stats;

    public float currentCooldown;
    public GameObject explosionPrefab;
    public Animation weaponAnimator;
    public Shot shotPrefab;
    public Transform shotPlace;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

	public void Shoot()
    {
        if (currentCooldown >= 0)
            return;

        currentCooldown = stats.cooldown;
        rb.AddForce(-transform.forward * stats.recoil);

        Shot s = (Instantiate(shotPrefab.gameObject, shotPlace.position + shotPlace.forward * shotPrefab.transform.localScale.z, shotPlace.rotation) as GameObject).GetComponent<Shot>();
        s.transform.localScale *= stats.size;
        Physics.IgnoreCollision(s.GetComponent<Collider>(), GetComponent<Collider>());

        s.speed = stats.speed;
        s.gravity = stats.gravity;
        s.damage = stats.damage;
        s.knockback = stats.knockback;
        s.rebound = stats.rebound;
        s.explosion = stats.explosion;

        weaponAnimator.Play("Shoot");
        
        AnimationState anim = weaponAnimator.PlayQueued("Reload", QueueMode.CompleteOthers);
        anim.speed = anim.length / stats.cooldown;
	}

    void FixedUpdate()
    {
        currentCooldown -= Time.fixedDeltaTime;
    }
}
