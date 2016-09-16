using UnityEngine;
using System.Collections;

public class BombDropper : MonoBehaviour {

    [SerializeField]
    private GameObject bomb;

	void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            var spawnedObj = (GameObject)Instantiate(bomb, transform.position, Quaternion.identity);
        }
    }
}
