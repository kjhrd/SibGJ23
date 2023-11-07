using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject endGame;
    public GameObject cam;
    public float speed;
    public Rigidbody2D rb;
    public Vector2 movement;
    public GameObject target;
    public bool isControllabe = true;
    public Animator animator;
    public SpriteRenderer spriteRenderer;
    public Task task1;
    public Task task2;
    public Task task3;
    public Task task4;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (task1.isCompleated && task2.isCompleated && task3.isCompleated && task4.isCompleated)
        {
            isControllabe = false;
            endGame.SetActive(true);
        }
        if (isControllabe)
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            animator.SetFloat("x", Mathf.Abs(moveHorizontal));
            animator.SetFloat("y", -moveVertical);

            spriteRenderer.flipX = !(moveHorizontal<-.01f);

            movement = new Vector2(moveHorizontal, moveVertical);
            rb.velocity = movement * speed;

            if (target != null && Input.GetKeyDown(KeyCode.E))
            {
                target.GetComponent<Task>().StartMiniGame(target.GetComponent<Task>().currentMiniGame);
                isControllabe=false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "task")
        {
            target = other.gameObject;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Task")
        {
            target = null;
        }
    }
}
