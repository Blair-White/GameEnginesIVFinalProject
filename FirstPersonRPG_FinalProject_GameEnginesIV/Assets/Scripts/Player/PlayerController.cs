using UnityEngine;
using UnityEngine.UI;
//This Script is copied directly from character.move on unity website.
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //clean this all up if time.
    public GameObject HealthBar, ExpBar, oHitFlash, LevelupEffect, LevelUpUI, Sword, ShieldedBar, UiController, level1, level2, faceeffectlocation, regenEffect, HitEffect;
    private float health, exp, totalExpNeeded, expCalc, targetexpCalc, targetHealth, flashdelay, mDamage;
    private float StoneSkinReduction, giftcooldown, regenAmount, regenCount;
    public float[] levelupExps;
    private int myLevel, empowermultiplier, prayercharges;
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer, hitFlash, empowered, shielded;
    public bool AttackFrame;
    [SerializeField]
    private float playerSpeed = 2.0f;
    [SerializeField]
    private float jumpHeight = 1.0f;
    [SerializeField]
    private float gravityValue = -9.81f;
    private InputManager inputManager;
    private Transform cameraTransform;
    private int iAttackcount;
    private Vector3 lastPos;
    //talent bools
    public bool StoneSkin, Poison, Gift, Prayer, Regeneration, Runes;
    private void Start()
    {
        myLevel = 1;
        totalExpNeeded = levelupExps[myLevel];
        expCalc = 0; targetexpCalc = 0; exp = 0;
        health = 100; targetHealth = 100;
        controller = GetComponent<CharacterController>();
        inputManager = InputManager.Instance;
        cameraTransform = Camera.main.transform;
        mDamage = 25f;
        StoneSkinReduction = 0;
        level1 = GameObject.Find("LevelUp1"); level2 = GameObject.Find("LevelUp2");
        level1.SetActive(false); level2.SetActive(false);
        empowermultiplier = 2;
        giftcooldown = .5f;
        prayercharges = 1;
        regenAmount = 5;
    }

    private void FixedUpdate()
    {
        if (hitFlash)
        {
            flashdelay += Time.deltaTime;
            if (flashdelay > 0.05f)
            {
                oHitFlash.SetActive(false);
                hitFlash = false;
                flashdelay = 0;
            }

        }
    }
    private void LateUpdate()
    {
        

 

       

    }
    void Update()
    {
        if(Regeneration)
        {
            regenCount += Time.deltaTime;
            if(regenCount > 3)
            {
                targetHealth += regenAmount;
                regenCount = 0;
                Instantiate(regenEffect, faceeffectlocation.transform);
            }
        }


        Vector3 currentPos = transform.position;
        if (currentPos != lastPos && !Sword.GetComponent<SwordController>().isWalking) Sword.SendMessage("Walking");
        else
        if (currentPos == lastPos && Sword.GetComponent<SwordController>().isWalking) Sword.SendMessage("StoppedWalking");
        lastPos = currentPos;

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

        if (expCalc != targetexpCalc)
        {
            if (expCalc > targetexpCalc)
            {
                expCalc -= 0.1f;
            }
            if (expCalc < targetexpCalc)
            {
                expCalc += 0.1f;
            }
        }

        if (expCalc >= 100) LevelUp();

        HealthBar.GetComponent<RectTransform>().sizeDelta = new Vector2(health, 99);
        ExpBar.GetComponent<RectTransform>().sizeDelta = new Vector2(expCalc, 99);

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
        if(!shielded)
        {
            targetHealth -= (10 - StoneSkinReduction);
            hitFlash = true;
            oHitFlash.SetActive(true);
            oHitFlash.GetComponent<Image>().color = Color.red;
        }
        else
        {
            oHitFlash.SetActive(true);
            hitFlash = true;
            oHitFlash.GetComponent<Image>().color = Color.cyan;
            if (shielded)
            {
                if (Prayer) if (prayercharges == 0) { Unshield(); }
                if (Prayer) if (prayercharges > 0) { prayercharges--; return; }
                if (!Prayer) { Unshield(); }
            }
                
        }
    }

    void SkeleHit(GameObject enemy)
    {
        float applyDamage;
        if (!empowered) applyDamage = mDamage; else applyDamage = mDamage * empowermultiplier;

        if (AttackFrame == true)
        {
            AttackFrame = false;
            enemy.SendMessage("GotHit", applyDamage, SendMessageOptions.RequireReceiver);
            if (empowered) UnEmpower();
            Instantiate(HitEffect, enemy.transform);
        }

        if(Poison)
        {
            enemy.SendMessage("Poisoned");
        }

        
    }

    void Attacked()
    {
        AttackFrame = true;
    }
    void AttackEnded()
    {
        AttackFrame = false;
    }
    
    public void GrantExp(float granted)
    {
        exp += granted;
        targetexpCalc = exp / totalExpNeeded * 100;
    }

    private void Empower() { empowered = true; Sword.SendMessage("SetEmpoweredMat"); }

    private void UnEmpower() { empowered = false; Sword.SendMessage("SetNormalMat"); UiController.SendMessage("EmpowerEnded"); }
    private void ShieldMe() { shielded = true; ShieldedBar.SetActive(true); }
    private void Unshield() { shielded = false; ShieldedBar.SetActive(false); UiController.SendMessage("ShieldEnded"); }

    private void LevelUp()
    {
        Cursor.visible = true;
        //temp system to get it just done quick
        if (myLevel == 1) { level1.SetActive(true); }
        if(myLevel == 2) { level2.SetActive(true); }
        myLevel++;
        exp = 0;
        targetexpCalc = 0;
        totalExpNeeded = levelupExps[myLevel];
    }
    
    public void PoisonSelect() { Poison = true; level1.SetActive(false); Cursor.visible = false; }
    public void StoneSkinSelect() { StoneSkin = true; StoneSkinReduction = 2.5f; level1.SetActive(false); Cursor.visible = false; }
    public void GiftSelect() { Gift = true; level1.SetActive(false); Cursor.visible = false; UiController.SendMessage("GiftSelect"); }
    public void PrayerSelect() { Prayer = true; level2.SetActive(false); Cursor.visible = false; }
    public void RunesSelect() { Runes = true; level2.SetActive(false); Cursor.visible = false; empowermultiplier = 3; }
    public void RegenerationSelect() { Regeneration = true; level2.SetActive(false); Cursor.visible = false; }
}
// public bool StoneSkin, Poison, Gift, Prayer, Regeneration, Runes;