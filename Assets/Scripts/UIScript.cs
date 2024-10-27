using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    [SerializeField] PlayerScript player;
    [SerializeField] Text healthText;

    private PlayerScript observerForPlayer;

    // Start is called before the first frame update
    void Awake()
    {
        StartObservingHealth(player);
    }

    void Start()
    {
        healthText.text = "Health: " + PlayerScript.InstancePlayerAttributes.getHealth();
    }

    void StartObservingHealth(PlayerScript player)
    {
        observerForPlayer = player;
        observerForPlayer.Damage += OnDamageUi;
    }

    void OnDamageUi(int amount)
    {
        healthText.text = "Health: " + PlayerScript.InstancePlayerAttributes.getHealth();
    }

}