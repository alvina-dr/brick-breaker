using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KamikazeBrick : Brick
{
    [SerializeField] private int explosionRadius = 2;
    [SerializeField] private int KamikazeBrickDamage = 1;


    public override void Death()
    {
        Debug.Log("Coucou");
        // Trouve toutes les briques dans le rayon d'explosion
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explosionRadius);

        foreach (Collider2D collider in colliders)
        {
             Brick brick = collider.GetComponent<Brick>();
             if (brick != null)
             {
                brick.Damage(KamikazeBrickDamage);
             }
        }

        GPCtrl.Instance.AddScore(PointsForDestroying);
        Destroy(gameObject);
    }

}
