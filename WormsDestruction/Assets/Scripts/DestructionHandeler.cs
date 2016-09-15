using UnityEngine;
using System.Collections;


//This script is to be put on a 2D object that can be destroyed.
public class DestructionHandeler : MonoBehaviour, IDestructable2D {

    [SerializeField]
    private SpriteRenderer sr;

    private float widthWorld, heightWorld;
    private int widthPixel, heightPixel;

    [SerializeField]
    private string texName;

    private Color transpar = new Color(0, 0, 0, 0);
	
    void Start()
    {
        //get the texture for the object to be destroyed via string
        Texture2D tex = (Texture2D)Resources.Load(texName);
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
        //blast zone center in pixels/position of inpact in vector2 coords
        V2int c = World2Pixel(radius.bounds.center.x, radius.bounds.center.y);

        //blast radius in pixels
        int r = Mathf.RoundToInt(radius.bounds.size.x * widthPixel / widthWorld);

        int x, y, px, nx, py, ny, d;

        //cycle through all pixels within blast radius and make transparant
        for (x = 0; x <= r; x++)
        { 
            d = (int)Mathf.RoundToInt(Mathf.Sqrt(r * r - x * x));

            for (y = 0; y <= d; y++)
            {
                px = c.x + x;
                nx = c.x - x;
                py = c.y + y;
                ny = c.y - y;

                //make pixels within blast radius transparant
                sr.sprite.texture.SetPixel(px, py, transpar);
                sr.sprite.texture.SetPixel(nx, py, transpar);
                sr.sprite.texture.SetPixel(px, ny, transpar);
                sr.sprite.texture.SetPixel(nx, ny, transpar);
            }
        }

        InitSpriteDimensions();

        sr.sprite.texture.Apply();

        Destroy(GetComponent<PolygonCollider2D>());
        gameObject.AddComponent<PolygonCollider2D>();
    }
    
    private V2int World2Pixel(float x, float y)
    {
        V2int v = new V2int();

        //work out where destroyable bullet hit the ground on X axis
        float dx = x - transform.position.x;
        v.x = Mathf.RoundToInt(0.5f * widthPixel + dx * widthPixel / widthWorld);

        
        //work out where destroyable bullet hit the ground on Y axis
        float dy = y - transform.position.y;
        v.y = Mathf.RoundToInt(0.5f * heightPixel + dy * heightPixel / heightWorld);

        //v = vector position of bullet collision with ground
        return v;  
    }
}
