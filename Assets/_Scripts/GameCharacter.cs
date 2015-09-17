using UnityEngine;
using System.Collections;

public class GameCharacter : MonoBehaviour {

    public int life = 10000;

    Rigidbody rb;
    MutableShooter shooter;
	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        shooter = GetComponentInChildren<MutableShooter>();
	}

    // isso aqui deve ir num outro script só para input
    void Update()
    {
        if (Input.GetAxis("Fire1") != 0)
            Action1();
    }

    void Action1()
    {
        shooter.Shoot();
    }
    public void TakeDamage(int damage, Vector3 knockback)
    {
        life -= damage;
        if (life <= 0)
            Debug.Log(name + ": I'm dead");
        rb.AddForce(knockback);
    }
}
