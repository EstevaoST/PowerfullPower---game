using UnityEngine;
using System.Collections;

public class Explosion : MonoBehaviour {

    public float size;
    public int damage;
    public float knockback;

    public ParticleSystem effect;
    public LayerMask layerMask;
	// Use this for initialization
	void Start () {
        effect.startSize *= size;
        effect.startSpeed *= size;
        Collider[] col = Physics.OverlapSphere(transform.position, size, layerMask.value);
        Debug.DrawRay(transform.position, Vector3.up * size, Color.red,3);
        Debug.DrawRay(transform.position, -Vector3.up * size, Color.red,3);
        Debug.DrawRay(transform.position, Vector3.right * size, Color.red,3);
        Debug.DrawRay(transform.position, -Vector3.right * size, Color.red,3);
        Debug.DrawRay(transform.position, Vector3.forward * size, Color.red,3);
        Debug.DrawRay(transform.position, -Vector3.forward * size, Color.red,3);
        foreach (var item in col)
        {
            GameCharacter gc = item.GetComponent<GameCharacter>();
            if (gc != null)
            {
                gc.TakeDamage(damage,  (gc.transform.position - transform.position).normalized * knockback);
            }
        }
	}
    void Update()
    {
        if (!effect.IsAlive())
            Destroy(gameObject);
    }
}
