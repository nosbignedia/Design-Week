using UnityEngine;

public class Player2Controller : MonoBehaviour
{
    public GameObject player;
    public GameObject restartButton;
    public GameObject healthBar;
    public GameObject staminaBar;

    private float health = 100f;
    private float stamina = 100f;

    public float hitDamage = 10f;
    public float parryStaminaCost = 20f;
    public float hitStaminaCost = 10f;
    public float dodgeStaminaCost = 15f;
    public float staminaRegenRate = 10f;
    public float leanSpeed = 5f;

    private bool gameRestarted = false;

    void Update()
    {
        if (gameRestarted)
        {
            // Reset health and stamina
            health = 100f;
            stamina = 100f;

            // Update UI
            UpdateHealthBar();
            UpdateStaminaBar();

            gameRestarted = false;
        }

        // Player leaning
        float lean = Input.GetAxis("Player2Horizontal");
        player.transform.Translate(Vector3.right * lean * leanSpeed * Time.deltaTime);

        // Player actions
        if (Input.GetKeyDown(KeyCode.M) && stamina >= hitStaminaCost)
        {
            // Player punches
            health -= hitDamage;
            stamina -= hitStaminaCost;
        }

        if (Input.GetKeyDown(KeyCode.Period) && stamina >= parryStaminaCost)
        {
            // Player parries
            stamina -= parryStaminaCost;
        }

        if (Input.GetKeyDown(KeyCode.Comma) && stamina >= dodgeStaminaCost)
        {
            // Player dodges
            stamina -= dodgeStaminaCost;
        }

        // Restart the game if 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameRestarted = true;
        }

        // Update UI elements
        UpdateHealthBar();
        UpdateStaminaBar();

        // Regenerate stamina over time
        stamina = Mathf.Min(stamina + staminaRegenRate * Time.deltaTime, 100f);
    }

    void UpdateHealthBar()
    {
        healthBar.transform.localScale = new Vector3(health / 100f, 1f, 1f);
    }

    void UpdateStaminaBar()
    {
        staminaBar.transform.localScale = new Vector3(stamina / 100f, 1f, 1f);
    }
}


