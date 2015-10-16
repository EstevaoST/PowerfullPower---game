using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour {
    const string moveH = "MoveH";
    const string moveV = "MoveV";
    const string aimH = "AimH";
    const string aimV = "AimV";
    const string fire = "Fire";
    const string jump = "Jump";


    public int controlId;
    public RigidBodyCharacter character;

	// Use this for initialization
	void Start () {
        character = GetComponent<RigidBodyCharacter>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        float inpmh = Input.GetAxis(moveH + controlId);
        float inpmv = Input.GetAxis(moveV + controlId);
        float inpah = Input.GetAxis(aimH + controlId);
        float inpav = Input.GetAxis(aimV + controlId);
        float inpf = Input.GetAxis(fire + controlId);
        float inpj = Input.GetAxis(jump + controlId);

        character.move = new Vector3(inpmh, 0, inpmv);
        character.rotate = new Vector3(-inpav, inpah, 0);

        if (inpf >= 1)
            character.Fire();
        if (inpj >= 1)
            character.Jump();
	}
}
