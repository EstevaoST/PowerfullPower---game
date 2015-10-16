using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {
    public const int MAX_N_OF_PLAYERS = 4;
    public struct PlayerStruct
    {
        
    }
    public Camera cam1, cam2, cam3;
    public GameObject p1, p2, p3;
    private static int total = 2;

    // Use this for initialization
    void Start () {
        if (!Application.loadedLevelName.Equals("IntroSetup"))
            print(total);
        {

            if (total == 2)
            {
                //2Player
                cam1.GetComponent<Camera>().rect = new Rect(0, 0, .5f, 1);
                cam2.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 1);
                p1.SetActive(true);
                p2.SetActive(true);
                p3.SetActive(false);
            }
            else
            {

                //3Player
                cam1.GetComponent<Camera>().rect = new Rect(0, 0, .5f, 1);
                cam2.GetComponent<Camera>().rect = new Rect(0.5f, 0, 0.5f, 0.5f);
                cam3.GetComponent<Camera>().rect = new Rect(0.5f, 0.5f, 0.5f, 0.5f);
                p1.SetActive(true);
                p2.SetActive(true);
                p3.SetActive(true);
            }

            //....N max players? 4?
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        if (Application.loadedLevelName.Equals("IntroSetup"))
        {
              
            if (Input.GetKey(KeyCode.Alpha2))
            {
                total = 2;
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            if (Input.GetKey(KeyCode.Alpha3))
            {
                total = 3;
                Application.LoadLevel(Application.loadedLevel + 1);
            }
        }


    }
}
