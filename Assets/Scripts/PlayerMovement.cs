using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
   private Rigidbody2D _rb;

   public float moveSpeed;
   private Vector2 _moveDirection;
   
   public InputActionReference moveAction;
   public InputActionReference runAction;

   void Start()
   {
      _rb = GetComponent<Rigidbody2D>();
   }
   private void Update()
   {
      _moveDirection = moveAction.action.ReadValue<Vector2>();
   }

   private void FixedUpdate()
   {
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
}
