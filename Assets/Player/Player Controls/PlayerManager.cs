using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    Animator animator;
    InputManager inputManager;
    CameraManager cameraManager;
    PlayerLocomotion playerLocomotion;

    public bool isInteracting;

    public GameObject ragdollPrefab;

    [Header("Spore functions")]
    public Spores currentSpore;
    public GameObject mushroomHat;
    public GameObject shield;

    [Header("Respawn")]
    public Transform respawnPoint;
    public GameObject player;

    [Header("Pause")]
    public GameObject pauseWindow;
    [Header("Audio")]
    public AudioSource sporeChangeSound;

    private void Awake()
    {
        currentSpore = Spores.None;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
        Time.timeScale = 1.0f;
    }

    private void Update()
    {
        inputManager.HandleAllInputs();
        ChangeMushroomHatColor();


    }

    private void FixedUpdate()
    {
        playerLocomotion.HandleAllMovement();
    }

    private void LateUpdate()
    {
        //cameraManager.HandleAllCameraMovement();

        isInteracting = animator.GetBool("isInteracting");
        playerLocomotion.isJumping = animator.GetBool("isJumping");
        animator.SetBool("isGrounded", playerLocomotion.isGrounded);
    }

    public bool ContainsSpore(Spores requiredSpore)
    {
        if(currentSpore == requiredSpore)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public void ChangeMushroomHatColor()
    {
        switch (currentSpore)
        {
            case Spores.None:
                shield.gameObject.SetActive(false);
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.red, 0.01f);               
                break;

            case Spores.Water:
                shield.gameObject.SetActive(false);
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.blue, 0.01f);
                break;

            case Spores.Toxic:
                shield.gameObject.SetActive(false);
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.black, 0.01f);
                break;

            case Spores.Shielding:
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.yellow, 0.01f);
                shield.gameObject.SetActive(true);
                break;

            default:
                break;
        }
    }

    public void DeathState()
    {
        gameObject.transform.position = respawnPoint.position;
        Instantiate(ragdollPrefab, transform.position, transform.rotation);
        
        
    }
    public void HandlePause()
    {
        pauseWindow.SetActive(true);
        Time.timeScale = 0.0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
    }
}

public enum Spores
{
    None,
    Water,
    Toxic,
    Shielding
}
