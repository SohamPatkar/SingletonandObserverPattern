using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] Text healthText;
    [SerializeField] Text enemyCountText;
    [SerializeField] Text gameOverText;

    private PlayerScript observerForPlayer;
    private EnemySpawner enemySpawner;
    // Start is called before the first frame update
    void Awake()
    {
        StartObservingHealth(player);
        StartObservingEnemySpawner();
    }

    void Start()
    {
        gameOverText.enabled = false;
        healthText.text = "Health: " + PlayerScript.InstancePlayerAttributes.getHealth();
        enemyCountText.text = "Enemy active " + EnemySpawner.EnemySpawnerInstance.enemyCounter;
    }

    void StartObservingHealth(PlayerScript player)
    {
        observerForPlayer = player;
        observerForPlayer.Damage += OnDamageUi;
        observerForPlayer.Dead += OnDeadUi;
    }

    void StartObservingEnemySpawner()
    {
        enemySpawner = EnemySpawner.EnemySpawnerInstance;
        enemySpawner.activeEnemyCount += ActiveEnemy;
    }

    void OnDeadUi()
    {
        gameOverText.enabled = true;
        Time.timeScale = 0;
    }

    void ActiveEnemy(int enemyCount)
    {
        enemyCountText.text = "Enemy active " + EnemySpawner.EnemySpawnerInstance.enemyCounter;
    }

    void OnDamageUi(int amount)
    {
        healthText.text = "Health: " + PlayerScript.InstancePlayerAttributes.getHealth();
    }

}