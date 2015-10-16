using UnityEngine;
using System.Collections;

public class RigidBodyCharacter : MonoBehaviour {

    public Vector3 move;
    public Vector3 rotate;

    public float moveSpeed = 5;
    public float rotateSpeed = 5;
    public float jumpForce = 500;

    public Transform head;
    public MutableShooter shooter;
    public Rigidbody rb;

	void Start () {
        if (head == null)
            head = GetComponentInChildren<Camera>().transform;
        rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate () {
        transform.Translate(move * Time.fixedDeltaTime * moveSpeed, Space.Self);
        transform.Rotate(Vector3.up * rotate.y * rotateSpeed * Time.fixedDeltaTime, Space.Self);
        head.Rotate(Vector3.right * rotate.x * rotateSpeed * Time.fixedDeltaTime, Space.Self);
	}

    internal void Fire()
    {
        SendMessage("Shoot");
    }

    internal void Jump()
    {
        rb.AddRelativeForce(transform.up * jumpForce, ForceMode.Impulse);
    }
}
