using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] private EnemyDetails enemyDetails;
    private Transform playerTransform;
    private float speed;
    EnemySpawner enemySpawner = EnemySpawner.EnemySpawnerInstance;
    private void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        EnemyDetection();
    }

    void EnemyDetection()
    {
        transform.LookAt(new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z));
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z), (speed = Random.Range(0.5f, 3.0f)) * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {

            PlayerScript.InstancePlayerAttributes.TakeDamage(enemyDetails.enemyDamage);
            enemySpawner.enemyCounter--;
            Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Obstacle"))
        {
            enemySpawner.enemyCounter--;
            Destroy(gameObject);
        }
    }
}
