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
    public water[] water;

    private void Awake()
    {
        currentSpore = Spores.None;
        water = FindObjectsOfType<water>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        cameraManager = FindObjectOfType<CameraManager>();
        playerLocomotion = GetComponent<PlayerLocomotion>();
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
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.red, 0.01f);
                
                break;
            case Spores.Water:
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.blue, 0.01f);
                break;
            case Spores.Toxic:
                mushroomHat.GetComponent<MeshRenderer>().material.color = Color.Lerp(mushroomHat.GetComponent<MeshRenderer>().material.color, Color.black, 0.01f);
                break;
            default:
                break;
        }
    }

    public void DeathState()
    {
        Instantiate(ragdollPrefab, transform.position, transform.rotation);
        gameObject.SetActive(false);
        playerLocomotion.enabled = false;
        inputManager.enabled = false;
        animator.enabled = false;
        this.enabled = false;
        
        
    }

}

public enum Spores
{
    None,
    Water,
    Toxic
}
