using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChracterController : MonoBehaviour
{
    [SerializeField]
    float HorizontalSpeed =10f;
    [SerializeField]
    float JumpPower;
    [SerializeField]
    GameObject Character;

    Rigidbody m_CharRigidBody;
    CapsuleCollider m_CharColl;
    float m_CharHeight = 0f;

     Animator m_CharacterAnimator;

    public float speed = 10.0f;
    public float gravity = 10.0f;
    public float maxVelocityChange = 10.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    private bool grounded = false;



    // Start is called before the first frame update
    void Start()
    {
      m_CharRigidBody =  this.GetComponent<Rigidbody>();
      m_CharColl = this.GetComponent<CapsuleCollider>();
      m_CharHeight = m_CharColl.height;
      m_CharacterAnimator = GetComponentInChildren<Animator>();

      if (m_CharacterAnimator == null)
           Debug.LogError("Character Animator");

      if (m_CharHeight == 0)
           Debug.LogError("Character height is zero");
    }

    // Update is called once per frame
    void Update()
    {      
  /*      float vAxis = Input.GetAxis("Vertical");
        float hAxis = Input.GetAxis("Horizontal");

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
        {
            var targetVelocity = new Vector3(hAxis, 0f, 0f);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= HorizontalSpeed;

            var velocity = m_CharRigidBody.velocity;
            var velocityChange = targetVelocity - velocity;
            velocityChange.x = Mathf.Clamp(velocityChange.x, -HorizontalSpeed, HorizontalSpeed);
            
            m_CharRigidBody.AddForce(new Vector3(velocityChange.x, velocityChange.y, 0f), ForceMode.VelocityChange);

          //  m_CharacterAnimator.SetBool("IsWalking", true);
            if (hAxis > 0f)
            {
                Debug.Log("Moving right");
                if(!Vector3.Equals(Character.transform.localRotation, new Vector3(0f, 0f, 0f)))
                Character.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
            else
            {
                Debug.Log("Moving Left");
                if (!Vector3.Equals(Character.transform.localRotation, new Vector3(0f, 180f, 0f)))
                Character.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
        }
        else if(Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))
        {
         ///   m_CharacterAnimator.SetBool("IsWalking", false);
        }

        Debug.DrawRay(this.transform.position, Vector3.down * m_CharHeight / 1.9f, Color.red);
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow))
        {
            JumpCharacter();
        }*/
    }

    void FixedUpdate()
    {
        if (grounded)
        {
            var hAxis = Input.GetAxis("Horizontal");
            // Calculate how fast we should be moving
            Vector3 targetVelocity = new Vector3(0f, 0, hAxis);
            targetVelocity = transform.TransformDirection(targetVelocity);
            targetVelocity *= speed;

            // Apply a force that attempts to reach our target velocity
            Vector3 velocity = m_CharRigidBody.velocity;
            Vector3 velocityChange = (targetVelocity - velocity);
            velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
           // velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
            velocityChange.y = 0;
            m_CharRigidBody.AddForce(velocityChange, ForceMode.VelocityChange);
            m_CharacterAnimator.SetBool("IsWalking", true);
            if (targetVelocity.Equals(Vector3.zero))
            {
                m_CharacterAnimator.SetBool("IsWalking", false);
            }

            if (hAxis > 0f)
            {
                Debug.Log("Moving right");
                if (!Vector3.Equals(Character.transform.localRotation, new Vector3(0f, 0f, 0f)))
                    Character.transform.localRotation = Quaternion.Euler(new Vector3(0f, 0f, 0f));
            }
            else if (hAxis < 0f)
            {
                Debug.Log("Moving Left");
                if (!Vector3.Equals(Character.transform.localRotation, new Vector3(0f, 180f, 0f)))
                    Character.transform.localRotation = Quaternion.Euler(new Vector3(0f, 180f, 0f));
            }
            


            // Jump
            if (canJump && Input.GetButton("Jump"))
            {
                m_CharacterAnimator.SetTrigger("IsJumping");
                m_CharRigidBody.velocity = new Vector3(velocity.x, CalculateJumpVerticalSpeed(), 0f);
            }
        }

        // We apply gravity manually for more tuning control
        m_CharRigidBody.AddForce(new Vector3(0, -gravity * m_CharRigidBody.mass, 0));

        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }

    float CalculateJumpVerticalSpeed()
    {
        // From the jump height and gravity we deduce the upwards speed 
        // for the character to reach at the apex.
        return Mathf.Sqrt(2 * jumpHeight * gravity);
    }

    void JumpCharacter()
    {
        int layerMask = 1 << 8;
     
       
        if (Physics.Raycast(this.transform.position, Vector3.down, out RaycastHit info, m_CharHeight/1.9f , layerMask))
        {
            m_CharRigidBody.AddForce(new Vector3(0f,JumpPower ,0f), ForceMode.Impulse);
            Debug.Log("Collided with Ground");
        }
        else
        {
            Debug.Log("Off the Ground");
        }
    }
}
