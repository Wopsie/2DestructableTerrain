using UnityEngine;
using System.Collections;

public interface IDestructable2D {

    void DestroyTerrain(CircleCollider2D radius);
    void AddPoints(int points);
}
