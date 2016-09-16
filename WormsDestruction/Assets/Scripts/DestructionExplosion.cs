using UnityEngine;
using System.Collections;

public class DestructionExplosion : MonoBehaviour {

    private bool Detonated = false;
    [SerializeField]
    private DestructionZoner bomb;
    [SerializeField]
    private Rigidbody2D rb;

    public delegate void DestroyCaller();
    public DestroyCaller CallDestroy;

    [SerializeField]
    private float scaleFactor;

    void Start()
    {
        gameObject.transform.localScale = Vector3.zero;

        //bomb = GetComponent<DestructionZoner>();

        bomb.CallExplosion += Explode;
    }


    void Explode()
    {
        bomb.CallExplosion -= Explode;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gameObject.transform.localScale = new Vector3(1, 1, 1);
        Detonated = true;
    }

    void Update()
    {
        if(Detonated)
        {
            //transform.localScale = new Vector3(Mathf.Lerp(1f, 0f, 1f), Mathf.Lerp(1f,0f,1f), Mathf.Lerp(1f,0f,1f));
            gameObject.transform.localScale = transform.localScale - new Vector3(scaleFactor, scaleFactor, scaleFactor);

            if(transform.localScale.x <= 0f)
            {
                if(CallDestroy != null)
                {
                    CallDestroy();
                }
            }
        }
            
    }

}
