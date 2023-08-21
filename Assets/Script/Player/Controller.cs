using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class Controller : MonoBehaviour
{
    #region variables
    public Player player;
    public Animator anim;
    private Transform playerVisual;
    public PlayerInput _input;
    private Rigidbody rg;
    private CombatManager combatManager;

    public DetectedEnemies detecter;

    private Vector3 velocity;

    #endregion

    #region internal functions unity

    private void Start()
    {
        //_input = GetComponent<PlayerInput>();
        rg = GetComponent<Rigidbody>();
        player.life.setMaxLifeDefault();
        player.speed.setDefault();
        playerVisual = anim.GetComponent<Transform>();
        combatManager = GetComponent<CombatManager>();
    }
    private void Update()
    {
        if (combatManager.noMove) Move();
        SelectControllerHit();

        if (_input.actions["AutoDamage"].WasPressedThisFrame()) { player.setDamage(1, Elements.physics); }

    }

    #endregion

    public void Move()
    {

        Vector2 movement = _input.actions["Moving"].ReadValue<Vector2>();

        if (movement.x != 0 || movement.y != 0)
        {
            velocity = new Vector3(movement.x, 0, movement.y) * player.speed.getSpeed();

            velocity.y = rg.velocity.y;

            //            Debug.Log(Mathf.Atan2(movement.x, movement.y));

            playerVisual.eulerAngles = new Vector3(0, (Mathf.Atan2(movement.x, movement.y) * 180) / Mathf.PI, 0);

            rg.velocity = velocity;

            anim.SetFloat("speed", movement.magnitude);
            anim.SetBool("walking", true);
        }
        else
        {
            rg.velocity = new Vector3(0, 0, 0);
            anim.SetBool("walking", false);
        }

    }

    public void SelectControllerHit()
    {
        if (_input.actions["AttackController"].WasPerformedThisFrame())
        {

            if (combatManager.canReceiveInput)
            {
                Transform enemy = detecter.getEnemyClosed(transform);

                if (transform != enemy)
                {
                    Vector2 difference = new Vector2(transform.position.x, transform.position.z) - new Vector2(enemy.position.x, enemy.position.z);

                    playerVisual.eulerAngles = new Vector3(0, (Mathf.Atan2(-difference.x, -difference.y) * 180) / Mathf.PI, 0);
                }
            }


            combatManager.Attack();
        }
    }

}
