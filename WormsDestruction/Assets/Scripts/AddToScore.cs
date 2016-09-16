using UnityEngine;
using System.Collections;

public class AddToScore : MonoBehaviour , IDestructable2D{

    [SerializeField]
    private Score score;

    public void DestroyTerrain(CircleCollider2D radius) { }

    public void AddPoints(int points)
    {
        score.IncrementScore();
        Destroy(gameObject);
    }
}
