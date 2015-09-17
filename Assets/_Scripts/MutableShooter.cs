using UnityEngine;
using System.Collections;

public class MutableShooter : MonoBehaviour
{

    public float speed; //
	public float size; //
	public float gravity; //
	public int damage; //
	public float knockback; //
	public float cooldown; //
	public int rebound; //
	public float explosion; 
	public float recoil; //

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

        currentCooldown = cooldown;
        rb.AddForce(-transform.forward * recoil);

        Shot s = (Instantiate(shotPrefab.gameObject, shotPlace.position + shotPlace.forward * shotPrefab.transform.localScale.z, shotPlace.rotation) as GameObject).GetComponent<Shot>();
        s.transform.localScale *= size;
        Physics.IgnoreCollision(s.GetComponent<Collider>(), GetComponent<Collider>());

        s.speed = speed;
        s.gravity = gravity;
        s.damage = damage;
        s.knockback = knockback;
        s.rebound = rebound;
        s.explosion = explosion;

        weaponAnimator.Play("Shoot");
        
        AnimationState anim = weaponAnimator.PlayQueued("Reload", QueueMode.CompleteOthers);
        anim.speed = anim.length / cooldown;
	}

    void FixedUpdate()
    {
        currentCooldown -= Time.fixedDeltaTime;
    }
}
