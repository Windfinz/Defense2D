using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float damage;

    private PlayerHealth health;

    private void Start()
    {
        health = FindObjectOfType<PlayerHealth>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        LookAtPlayer();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Shield")) 
        {
            Destroy(this.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            health.TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        ArrowSpawner spawner = FindObjectOfType<ArrowSpawner>();
        spawner.OnEnemyKilled();
    }

    private void LookAtPlayer()
    {
        Vector3 dir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle - 90);
    }

}
