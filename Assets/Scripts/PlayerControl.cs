using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    public enum FACEDIRECTION {FACELEFT = -1, FACERIGHT = 1};
    public FACEDIRECTION Facing = FACEDIRECTION.FACERIGHT;
    public LayerMask GroundLayer;
    public CircleCollider2D FeetCollider = null;
    public bool isGrounded = false;
    public string HorzAxis = "Horizontal";
    public string JumpButton = "Jump";
    public float MaxSpeed = 50f;
    public float JumpPower = 600f;
    public float JumpTimeOut = 1f;
    public bool CanControl = true;
    public static PlayerControl PlayerInstance = null;
    public GameObject DeathPArticles = null;
    public float hp = 0;
    public static float Health
    {
        get
        {
            return _Health;
        }

        set
        {
            _Health = value;

            if (_Health <= 0)
            {
                Die();
            }
        }
    }

    [SerializeField] private static float _Health = 100f;
    private Rigidbody2D ThisBody = null;
    private bool CanJump = true;

    private void Awake()
    {
        ThisBody = GetComponent<Rigidbody2D>();
        PlayerInstance = this;
    }

    private bool GetGrounded()
    {
        Vector2 CircleCenter = new Vector2(transform.position.x, transform.position.y) + FeetCollider.offset;
        Collider2D[] HitColliders = Physics2D.OverlapCircleAll(CircleCenter, FeetCollider.radius, GroundLayer);
        return HitColliders.Length > 0;
    }

    private void FlipDirection()
    {
        Facing = (FACEDIRECTION)((int)Facing * -1f);
        Vector3 LocalScale = transform.localScale;
        LocalScale.x *= -1f;
        transform.localScale = LocalScale;
    }

    private void Jump()
    {
        if (!isGrounded || !CanJump)
            return;
        ThisBody.AddForce(Vector2.up * JumpPower);
        CanJump = false;
        Invoke("ActivateJump", JumpTimeOut);
    }

    private void ActivateJump()
    {
        CanJump = true;
    }

    private void FixedUpdate()
    {
        hp = _Health;
        if (!CanControl || Health <= 0f)
        {
            return;
        }
        isGrounded = GetGrounded();
        float Horz = CrossPlatformInputManager.GetAxis(HorzAxis);
        ThisBody.AddForce(Vector2.right * Horz * MaxSpeed);

        if (CrossPlatformInputManager.GetButton(JumpButton))
        {
            Jump();
        }
        ThisBody.velocity = new Vector2(Mathf.Clamp(ThisBody.velocity.x, -MaxSpeed, MaxSpeed), Mathf.Clamp(ThisBody.velocity.y, -Mathf.Infinity, JumpPower));

        if ((Horz < 0f && Facing != FACEDIRECTION.FACELEFT) || (Horz > 0f && Facing != FACEDIRECTION.FACERIGHT))
        {
            FlipDirection();
        }
    }

    private void OnDestroy()
    {
        PlayerInstance = null;
    }

    private static void Die()
    {
        if (PlayerControl.PlayerInstance.DeathPArticles != null)
        {
            Instantiate(PlayerControl.PlayerInstance.DeathPArticles, PlayerControl.PlayerInstance.transform.position, PlayerControl.PlayerInstance.transform.rotation);
        }

        Destroy(PlayerControl.PlayerInstance.gameObject);
    }

    public static void Reset()
    {
        Health = 100f;
        SceneChanger.LastTarget = new Vector3(1.51f, -1.93f, 0f);
    }
}
