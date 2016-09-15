using UnityEngine;
using System.Collections;

public class DestructionExplosion : MonoBehaviour {

    private bool Detonated = false;
    [SerializeField]
    private DestructionZoner bomb;

    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;

        //bomb = GetComponent<DestructionZoner>();

        bomb.CallExplosion += Explode;
    }


    void Explode()
    {
        Debug.Log("Explode");
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Detonated = true;
    }

    void Update()
    {
        if(Detonated)
            gameObject.transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, 2f);
    }

}
