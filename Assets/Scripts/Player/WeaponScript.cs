using UnityEngine;

/// <summary>
/// Crée des projectiles
/// </summary>
public class WeaponScript : MonoBehaviour
{
    //--------------------------------
    // 1 - Designer variables
    //--------------------------------

    /// <summary>
    /// Prefab du projectile
    /// </summary>
    public Transform shotPrefab;

    /// <summary>
    /// Temps de rechargement entre deux tirs
    /// </summary>
    public float shootingRate = 0.25f;

    //--------------------------------
    // 2 - Rechargement
    //--------------------------------

    private float shootCooldown;

    void Start()
    {
        shootCooldown = 0f;
    }

    void Update()
    {
        if (shootCooldown > 0)
        {
            shootCooldown -= Time.deltaTime;
        }
    }

    //--------------------------------
    // 3 - Tirer depuis un autre script
    //--------------------------------

    /// <summary>
    /// Création d'un projectile si possible
    /// </summary>
    public void Attack(bool isEnemy)
    {
        if (CanAttack)
        {
            shootCooldown = shootingRate;
            int dir = GameObject.Find("Player").GetComponent<Move>().Shot;
            // Création d'un objet copie du prefab
            var shotTransform = Instantiate(shotPrefab) as Transform;

            // Position
            Vector3 pos = transform.position;
            pos.x += dir;
            shotTransform.position = pos;

            //scale
            Vector3 theScale = transform.localScale;
            theScale.x *= dir;
            shotTransform.localScale = theScale;
            // Propriétés du script
            ShotScript shot = shotTransform.gameObject.GetComponent<ShotScript>();
            if (shot != null)
            {
                shot.isEnemyShot = isEnemy;
            }

            
            // On saisit la direction pour le mouvement
            ShotMove move = shotTransform.gameObject.GetComponent<ShotMove>();
            if (move != null)
            {
             
              move.direction = this.transform.right * GameObject.Find("Player").GetComponent<Move>().Shot; // ici la droite sera le devant de notre objet
              
            }
        }
    }

    /// <summary>
    /// L'arme est chargée ?
    /// </summary>
    public bool CanAttack
    {
        get
        {
            return shootCooldown <= 0f;
        }
    }
}