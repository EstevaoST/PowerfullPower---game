using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {
    public float speed; //
    public float gravity; //
    public int damage; //
    public float knockback; //
    public int   rebound; //
    public float explosion;
    public LayerMask raycastMask;

    private Rigidbody rb;
    RaycastHit rh = new RaycastHit();
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
    void FixedUpdate()
    {
        if (rb.velocity.magnitude < 0.01f * speed)
            Destroy(gameObject);

        Vector3 dir = Vector3.down * gravity;
        rb.velocity +=  dir * Time.fixedDeltaTime;

        transform.LookAt(transform.position + rb.velocity, transform.up);

        if (Physics.Raycast(new Ray(transform.position, rb.velocity), out rh, transform.localScale.z * (1 + Time.fixedDeltaTime), raycastMask.value))
        {

            Debug.DrawRay(rh.point, rh.normal * 10, Color.yellow, 3);
            Debug.DrawRay(rh.point, -rb.velocity * 10, Color.blue, 3);

            rb.velocity = Vector3.Reflect(rb.velocity.normalized, rh.normal) * speed;

            Hited(rh.collider);

            Debug.DrawRay(rh.point, rb.velocity * 10, Color.red, 3);
            
        }
    }

    private void Hited(Collider collider)
    {
        if (rebound-- <= 0)
            Destroy(gameObject);

        if (explosion <= 0)
        {
            GameCharacter gc = collider.GetComponent<GameCharacter>();
            if (gc != null)
            {
                gc.TakeDamage(damage, transform.forward * knockback);
            }
        }
        else
        {

        }
    }

    void OnCollisionEnter(Collision col)
    {
        Hited(col.collider);        
    }
}
