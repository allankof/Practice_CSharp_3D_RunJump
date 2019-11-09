using UnityEngine;

public class Boy : MonoBehaviour
{
    [Header("移動速度"), Range(0f, 100f)]
    public float speed = 1.5f;
    [Header("跳躍高度"), Range(100, 1500)]
    public int jump = 100;

    private Animator ani;

    private Rigidbody rb;
    bool isGround;

    public AudioClip soundJump;
    private AudioSource audioSource;

    private void Start()
    {
        ani = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(0, 0, speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "地板")
        {
            isGround = true;
        }
    }

    public void Jump()
    {
        if (isGround)
        {
            isGround = false;
            ani.SetBool("跳躍開關", true);
            rb.AddForce(new Vector3(0, jump, 0));
            audioSource.PlayOneShot(soundJump, 0.6f);
        }
    }

    public void ResetAnimator()
    {
        ani.SetBool("跳躍開關", false);
    }
}
