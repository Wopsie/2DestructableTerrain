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
        StartCoroutine(ScaleDown());
    }

    IEnumerator ScaleDown()
    {
        Debug.Log("Coroutine started");
        if(Detonated)
        {
            for (int i = 0; i < 30; i++)
            {
                //scale down explosion
                gameObject.transform.localScale = transform.localScale - new Vector3(scaleFactor, scaleFactor, scaleFactor);
                Debug.Log("Scaling Down Via Coroutine");
                //check if explosion is scaled gone
                if (transform.localScale.x <= 0)
                {
                    if (CallDestroy != null)
                    {
                        CallDestroy();
                    }
                }

                yield return null;
            }
        }
    }
}
