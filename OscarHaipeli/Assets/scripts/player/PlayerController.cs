using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    public Transform gunTranform;
    public float moveSpeed = 5f;

    private Master controls;
    private Rigidbody2D body;
    private Vector2 moveInput;

    void Awake(){
     controls = new Master();
     body = GetComponent<Rigidbody2D>();
    }

    void OnEnable() {
        controls.Enable();
    }

    void OnDisable() {
        controls.Disable();
    }
    // Start is called before the first frame update
    void Update()
    {
      Shoot();  
    }
    
    void Shoot()
    {
        if(controls.player.fire.triggered){
        Debug.Log("ampuu");
        GameObject bullet = ammusPoolManager.Instance.GetBullet();
        bullet.transform.position = gunTranform.position;
        bullet.transform.rotation = gunTranform.rotation;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      Move();  
    }
    void Move(){
        moveInput = controls.player.move.ReadValue<Vector2>();
        Vector2 movement = new Vector2(moveInput.x, moveInput.y) * moveSpeed * Time.fixedDeltaTime;
        body.MovePosition(body.position + movement);    
    }
}
