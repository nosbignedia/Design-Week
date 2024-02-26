using System.Numerics;
using System;
using UnityEngine;

public class PunchOutGame : MonoBehaviour
{
    public gameobject player1;
    public gameobject player2;
    public gameobject restartButton;
    public gameobject player1HealthBar;
    public gameobject player2HealthBar;
    public gameobject player1StaminaBar;
    public gameobject player2StaminaBar;

    // Health and stamina variables
    private float player1Health = 100f;
    private float player2Health = 100f;
    private float player1Stamina = 100f;
    private float player2Stamina = 100f;

    // Speed and other movement-related variables
    public float moveSpeed = 5f;
    public float staminaRegenRate = 2f;
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

        // Player movement
        float player1MoveInput = Input.GetAxis("Player1Horizontal");
        float player2MoveInput = Input.GetAxis("Player2Horizontal");

        player1.transform.Translate(Vector3.right * player1MoveInput * moveSpeed * Time.deltaTime);
        player2.transform.Translate(Vector3.right * player2MoveInput * moveSpeed * Time.deltaTime);

        // Restart the game if '5' key is pressed
        if (Input.GetKeyDown(Players.Coin))
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


