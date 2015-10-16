using UnityEngine;
using System.Collections;

public class MutableShooter : MonoBehaviour
{

    public Stats stats;

    public float currentCooldown;
    public Explosion explosionPrefab;
    public Animation weaponAnimator;
    public Shot shotPrefab;
    public Transform shotPlace;

    private RigidBodyCharacter rbc;

    void Start()
    {
        rbc = GetComponent<RigidBodyCharacter>();
    }

	public void Shoot()
    {
        if (currentCooldown >= 0)
            return;

        currentCooldown = stats.Cooldown;

        Shot s = (Instantiate(shotPrefab.gameObject, shotPlace.position + shotPlace.forward * stats.Size / 20, shotPlace.rotation) as GameObject).GetComponent<Shot>();
        s.transform.localScale *= stats.Size;
        s.explosionPrefab = explosionPrefab;
        Physics.IgnoreCollision(s.GetComponent<Collider>(), GetComponent<Collider>());

        s.speed = stats.Speed;
        s.gravity = stats.Gravity;
        s.damage = (int)stats.Damage;
        s.knockback = stats.Knockback;
        s.rebound = (int)stats.Rebound;
        s.explosion = stats.Explosion;

        weaponAnimator.Play("Shoot");
        
        AnimationState anim = weaponAnimator.PlayQueued("Reload", QueueMode.CompleteOthers);
        anim.speed = anim.length / stats.Cooldown;

        rbc.rb.AddForce(-transform.forward * stats.Recoil);
        rbc.transform.Rotate(Vector3.up * Random.Range(-0.5f, 0.5f) * Mathf.Sqrt(Mathf.Sqrt(stats.Recoil)), Space.Self);
        rbc.head.Rotate(-Vector3.right * Random.Range(0.0f, 1.0f) * Mathf.Sqrt(Mathf.Sqrt(stats.Recoil)), Space.Self);
	}

    void FixedUpdate()
    {
        currentCooldown -= Time.fixedDeltaTime;
    }
}
