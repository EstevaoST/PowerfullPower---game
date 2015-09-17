using UnityEngine;
using System.Collections;

public class Shot : MonoBehaviour {

    public float speed; //
    public float gravity; //
    public int damage; //
    public float knockback; //
    public int   rebound; //
    public float explosion; 

    void FixedUpdate()
    {
        // não usar translate, já é relativo ao transform
        Vector3 dir = transform.forward * speed + Vector3.down * gravity;
        transform.position +=  dir * Time.fixedDeltaTime;
        transform.LookAt(transform.position + dir, transform.up);
    }

    void OnTriggerEnter(Collider col)
    {

    }
    void OnCollisionStay(Collision col)
    {
        if (rebound-- <= 0)
            Destroy(gameObject);

        if(explosion <= 0)
        {
            GameCharacter gc = col.transform.GetComponent<GameCharacter>();
            if (gc != null)
            {
                gc.TakeDamage(damage, transform.forward * knockback);
            }
        }
    }
}
