using UnityEngine;
using UnityEngine.UI;
//This Script is copied directly from character.move on unity website.
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    public GameObject HealthBar, oHitFlash;
    private float health, targetHealth, flashdelay; 
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer, hitFlash;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    private void Start()
    {
        health = 100; targetHealth = 100;
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        if (hitFlash)
        {
            flashdelay += Time.deltaTime;
            if (flashdelay > 0.1f)
            {
                oHitFlash.SetActive(false);
                hitFlash = false;
                flashdelay = 0;
            }

        }
    }
    void Update()
    {
        
        if(health != targetHealth)
        {
            if (health > targetHealth)
            {
                health -= 0.1f;
            }
            if(health < targetHealth)
            {
                health += 0.1f;
            }
        }

        HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health, 99);
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movement = inputManager.GetPlayerMovement();
        Vector3 move = new Vector3(movement.x, 0f, movement.y);
        move = cameraTransform.forward * move.z + cameraTransform.right * move.x;
        controller.Move(move * Time.deltaTime * playerSpeed);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (inputManager.PlayerJumped() && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    public void SkeleAttacked()
    {
        targetHealth -= 10;
        hitFlash = true;
        oHitFlash.SetActive(true);
    }

    
}
