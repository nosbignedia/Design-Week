using UnityEngine;

public class PunchOutGame : MonoBehaviour
{
    public GameObject player1;
    public GameObject player2;
    public GameObject restartButton;
    public GameObject player1HealthBar;
    public GameObject player2HealthBar;
    public GameObject player1StaminaBar;
    public GameObject player2StaminaBar;

    private float player1Health = 100f;
    private float player2Health = 100f;
    private float player1Stamina = 100f;
    private float player2Stamina = 100f;

    public float hitDamage = 10f; // Adjust damage as needed
    public float parryStaminaCost = 20f; // Cost of parrying
    public float hitStaminaCost = 10f; // Cost of hitting
    public float dodgeStaminaCost = 15f; // Cost of dodging
    public float staminaRegenRate = 5f; // Rate at which stamina regenerates

    private bool gameRestarted = false;

    void Update()
    {
        if (gameRestarted)
        {
            // Reset player positions
            player1.transform.position = new Vector3(-5f, 0f, 0f);
            player2.transform.position = new Vector3(5f, 0f, 0f);

            // Reset health and stamina
            player1Health = 100f;
            player2Health = 100f;
            player1Stamina = 100f;
            player2Stamina = 100f;

            // Update UI
            UpdateHealthBars();
            UpdateStaminaBars();

            gameRestarted = false;
        }

        // Player hitting, parry, and dodge logic
        if (Input.GetKeyDown(KeyCode.LeftControl) && player1Stamina >= hitStaminaCost)
        {
            // Player 1 hits
            player2Health -= hitDamage;
            player1Stamina -= hitStaminaCost;
        }
        else if (Input.GetKeyDown(KeyCode.RightControl) && player2Stamina >= hitStaminaCost)
        {
            // Player 2 hits
            player1Health -= hitDamage;
            player2Stamina -= hitStaminaCost;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && player1Stamina >= parryStaminaCost)
        {
            // Player 1 parries
            player1Stamina -= parryStaminaCost;
        }
        else if (Input.GetKeyDown(KeyCode.RightShift) && player2Stamina >= parryStaminaCost)
        {
            // Player 2 parries
            player2Stamina -= parryStaminaCost;
        }

        if (Input.GetKeyDown(KeyCode.A) && player1Stamina >= dodgeStaminaCost)
        {
            // Player 1 dodges
            player1Stamina -= dodgeStaminaCost;
            // Add dodge logic here
        }
        else if (Input.GetKeyDown(KeyCode.L) && player2Stamina >= dodgeStaminaCost)
        {
            // Player 2 dodges
            player2Stamina -= dodgeStaminaCost;
            // Add dodge logic here
        }

        // Restart the game if 'R' key is pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            gameRestarted = true;
        }

        // Update UI elements
        UpdateHealthBars();
        UpdateStaminaBars();

        // Regenerate stamina over time
        player1Stamina = Mathf.Min(player1Stamina + staminaRegenRate * Time.deltaTime, 100f);
        player2Stamina = Mathf.Min(player2Stamina + staminaRegenRate * Time.deltaTime, 100f);
    }

    void UpdateHealthBars()
    {
        player1HealthBar.transform.localScale = new Vector3(player1Health / 100f, 1f, 1f);
        player2HealthBar.transform.localScale = new Vector3(player2Health / 100f, 1f, 1f);
    }

    void UpdateStaminaBars()
    {
        player1StaminaBar.transform.localScale = new Vector3(player1Stamina / 100f, 1f, 1f);
        player2StaminaBar.transform.localScale = new Vector3(player2Stamina / 100f, 1f, 1f);
    }
}

