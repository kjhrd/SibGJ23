using UnityEngine;

public class Target : MonoBehaviour
{
    public bool canMove;
    public bool dragging;
    public Collider2D collider;
    public Task task;
    void Start()
    {
        
        collider = GetComponent<Collider2D>();
        canMove = false;
        dragging = false;

    }
    // Update is called once per frame
    void Update()
    {
        if (task.isCompleated)
        {
            Destroy(gameObject);
        }
        if (task.currentMiniGame == Task.MiniGameType.DragAndDrop)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                if (collider == Physics2D.OverlapPoint(mousePos))
                {
                    canMove = true;
                }
                else
                {
                    canMove = false;
                }
                if (canMove)
                {
                    dragging = true;
                }


            }
            if (dragging)
            {
                this.transform.position = mousePos;
            }
            if (Input.GetMouseButtonUp(0))
            {
                canMove = false;
                dragging = false;
            }
        }
        else if (task.currentMiniGame == Task.MiniGameType.ClickAll)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                if (collider == Physics2D.OverlapPoint(mousePos))
                {
                    task.targetCount--;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}