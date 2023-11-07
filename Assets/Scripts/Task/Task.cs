using UnityEngine;

public class Task : MonoBehaviour
{
    public Camera mainCamera;
    public Camera miniGameCamera;

    public Transform target;
    public Transform targetForTarget;
    public Transform positionPodushka;

    public GameObject podushka;

    public Sprite zel_podushka;

    public int targetCount;

    public float dist = 0f;

    public bool isStiralka;
    public bool isCharge;
    public bool isCompleated = false;

    public Animator animator;

    public PlayerController player;

    public enum MiniGameType
    {
        DragAndDrop,
        ClickAll
    }

    public MiniGameType currentMiniGame;

    void Start()
    {
        // ѕо умолчанию используетс€ основна€ камера
        SwitchToMainCamera();
    }

    void Update()
    {
        if (currentMiniGame == MiniGameType.DragAndDrop)
        {
            dist = Vector2.Distance(target.position, targetForTarget.position);
            if (Vector2.Distance(target.position, targetForTarget.position)<2f)
            {
                EndMiniGame();
            }
        }
        else if (currentMiniGame == MiniGameType.ClickAll)
        {
            if (targetCount == 0)
            {
                EndMiniGame();
            }
        }
    }

    public void StartMiniGame(MiniGameType miniGameType)
    {
        currentMiniGame = miniGameType;
        SwitchToMiniGameCamera();
    }

    public void EndMiniGame()
    {
        if (isStiralka)
        {
            animator.SetTrigger("kotic");
        }
        else if (isCharge)
        {
            podushka.transform.position = positionPodushka.transform.position;
            podushka.GetComponent<SpriteRenderer>().sprite = zel_podushka;
        }
        isCompleated = true;
        currentMiniGame = default;
        player.isControllabe = true;
        SwitchToMainCamera();
        gameObject.tag = "Untagged";
        this.GetComponent<Task>().enabled = false;
    }

    void SwitchToMainCamera()
    {
        mainCamera.enabled = true;
        mainCamera.gameObject.tag = "MainCamera";
        miniGameCamera.enabled = false;
        miniGameCamera.gameObject.tag = "Untagged";
    }

    void SwitchToMiniGameCamera()
    {
        mainCamera.enabled = false;
        mainCamera.gameObject.tag = "Untagged";
        miniGameCamera.enabled = true;
        miniGameCamera.gameObject.tag = "MainCamera";
    }
}
