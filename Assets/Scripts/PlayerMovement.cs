using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   //Components do Player
   private Rigidbody2D _rb;
   private Animator _anim;
   
   //Movimentação
   public float moveSpeed;
   private Vector2 _moveDirection;
   public int facingDirection = 1;
   
   //Input Actions
   public InputActionReference moveAction;
   public InputActionReference runAction;
   
   
   void Start()
   {
      _rb = GetComponent<Rigidbody2D>();
      _anim = GetComponent<Animator>();
   }
   private void Update()
   {
      _moveDirection = moveAction.action.ReadValue<Vector2>();
    
   }

   private void FixedUpdate()
   {
      _anim.SetBool("Walking", _moveDirection.x != 0 || _moveDirection.y != 0);
      if (_moveDirection.x < 0 && transform.localScale.x > 0 || _moveDirection.x > 0 && transform.localScale.x < 0) Flip();
      
      _rb.linearVelocity = new Vector2(_moveDirection.x * moveSpeed, _moveDirection.y * moveSpeed);
   }

   private void OnEnable()
   {
      runAction.action.started += Run;
   }

   private void OnDisable()
   {
      runAction.action.started -= Run;
   }
   private void Run(InputAction.CallbackContext obj)
   {
      Debug.Log("Correndo");
   }

   private void Flip()
   {
      facingDirection *= -1;
      transform.localScale = new Vector3(facingDirection, 1, 1);
   }
}
