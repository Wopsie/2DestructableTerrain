using UnityEngine;
using System.Collections;


//This script is to be put on a 2D object that can be destroyed.
public class DestructionHandeler : MonoBehaviour, IDestructable2D {

    [SerializeField]
    private SpriteRenderer sr;

    private float widthWorld, heightWorld;
    private int widthPixel, heightPixel;

    private Color transpar = new Color(0, 0, 0, 0);
	
    void Start()
    {
        //get the texture for the object to be destroyed via string
        Texture2D tex = (Texture2D)Resources.Load("Ground 1");
        //create clone of first texture to avoid changing the original
        Texture2D texClone = (Texture2D)Instantiate(tex);

        //give the sprite renderer the selected texture
        sr.sprite = Sprite.Create(texClone,
            new Rect(0f, 0f, texClone.width, texClone.height),
            new Vector2(0.5f, 0.5f), 100f);

        InitSpriteDimensions();
    }

    private void InitSpriteDimensions()
    {
        widthWorld = sr.bounds.size.x;
        heightWorld = sr.bounds.size.y;
        widthPixel = sr.sprite.texture.width;
        heightPixel = sr.sprite.texture.height;
    }

    public void DestroyTerrain(CircleCollider2D radius)
    {
        Debug.Log("Destroy Terrain Ran " + radius);

        V2int c = World2Pixel(radius.bounds.center.x, radius.bounds.center.y);
        // c => centro do circulo de destruiçao em pixels
        int r = Mathf.RoundToInt(radius.bounds.size.x * widthPixel / widthWorld);
        // r => raio do circulo de destruiçao em 

        int x, y, px, nx, py, ny, d;

        for (x = 0; x <= r; x++)
        {
            d = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - x * x));

            for (y = 0; y <= d; y++)
            {
                px = c.x + x;
                nx = c.x - x;
                py = c.y + y;
                ny = c.y - y;

                sr.sprite.texture.SetPixel(px, py, transpar);
                sr.sprite.texture.SetPixel(nx, py, transpar);
                sr.sprite.texture.SetPixel(px, ny, transpar);
                sr.sprite.texture.SetPixel(nx, ny, transpar);
            }
        }
        sr.sprite.texture.Apply();
        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }

    private V2int World2Pixel(float x, float y)
    {
        V2int v = new V2int();

        //work out where the destroyable bullet hit the ground
        float dx = x - transform.position.x;
        v.x = Mathf.RoundToInt(0.5f * widthPixel + dx * widthPixel / widthWorld);

        float dy = y - transform.position.y;
        v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);

        return v;
    }
}
