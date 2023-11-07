using UnityEngine;
using System.Collections;

public class AchievementNotification : MonoBehaviour
{
    public float notificationTime = 3f;

    // Аниматор должен быть настроен с анимациями "Show" и "Hide"
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void ShowAchievement()
    {
        // Установите текст уведомления здесь

        // Запустите анимацию "Show"
        animator.SetTrigger("Show");

        // Запустите корутину для скрытия уведомления через notificationTime секунд
        StartCoroutine(HideAfterTime(notificationTime));
    }

    IEnumerator HideAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Запустите анимацию "Hide"
        animator.SetTrigger("Hide");
    }
}
