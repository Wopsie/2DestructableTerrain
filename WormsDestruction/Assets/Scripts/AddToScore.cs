using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AddToScore : MonoBehaviour , IDestructable2D{

    [SerializeField]
    private Text scoreText;

    public void DestroyTerrain(CircleCollider2D radius) { }

    public void AddPoints(int points)
    {
        //scoreText = "Score : " + points;

        Destroy(gameObject);
    }
}
