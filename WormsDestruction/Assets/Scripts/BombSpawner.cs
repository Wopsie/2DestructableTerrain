using UnityEngine;
using System.Collections;


//this script spawns an object (this case bomb) at the mouse position when clicked
public class BombSpawner : MonoBehaviour {

    public GameObject bomb;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Input.mousePosition;
            Vector2 objectPos = Camera.main.ScreenToWorldPoint(mousePos);

            var spawnedObject = (GameObject)Instantiate(bomb, objectPos, Quaternion.identity);
        }
    }
}
