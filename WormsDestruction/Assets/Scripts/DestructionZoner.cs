using UnityEngine;
using System.Collections;

//this script is to be attatched to the object that collides with the destructable enviornment and causes destruction on collision
//it calls the appropriate method in the terrain that it collides with
public class DestructionZoner : MonoBehaviour {

    [SerializeField]
    private CircleCollider2D cc2D;

    [SerializeField]
    private float destructionRadius;

    public delegate void ExplosionCaller();
    public ExplosionCaller CallExplosion;

    [SerializeField]
    private SpriteRenderer sr;

    [SerializeField]
    private DestructionExplosion explosion;

    void Start()
    {
        //cc2D.enabled = false;
        cc2D.radius = destructionRadius;

        explosion.CallDestroy += RemoveObj;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        
        if(coll.gameObject.tag == "Ground")
        {
            //spawn circle with solid color
            if (CallExplosion != null)
            {
                CallExplosion();
            }

            sr.enabled = false;
            //call the DestroyTerrain method on the object collision happened with, give radius of cc2D collider as blast radius.
            ExecuteExtention.Execute<IDestructable2D>(coll.gameObject, x => x.DestroyTerrain(cc2D));
        }
    }

    void RemoveObj()
    {
        explosion.CallDestroy -= RemoveObj;
        Destroy(gameObject);
    }
}
