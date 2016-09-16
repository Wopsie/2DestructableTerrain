using UnityEngine;
using System.Collections;

public class BomberReticle : MonoBehaviour {

    [SerializeField]
    private GameObject reticle;

    void Start()
    {
        var bombReticle = (GameObject)Instantiate(reticle, transform.position, Quaternion.identity);

        reticle = bombReticle;
    }


	void Update()
    {
        RaycastHit2D reticlePos = Physics2D.Raycast(transform.position, Vector2.down);
        Debug.Log(reticlePos.point);

        reticle.transform.position = reticlePos.point;
    }
}
