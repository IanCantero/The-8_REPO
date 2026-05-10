using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour
{
    Animator anim;
    bool isOpen = false;
    bool isAnimating = false;

    [SerializeField] float animDuration = 2f;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    public void OnLookAt()
    {
        if (!isOpen && !isAnimating)
        {
            StartCoroutine(Open());
        }
    }

    public void OnLookAway()
    {
        if (isOpen && !isAnimating)
        {
            StartCoroutine(Close());
        }
    }

    IEnumerator Open()
    {
        isAnimating = true;

        anim.SetTrigger("Open");

        yield return new WaitForSeconds(animDuration);

        isOpen = true;
        isAnimating = false;
    }

    IEnumerator Close()
    {
        isAnimating = true;

        anim.SetTrigger("Close");

        yield return new WaitForSeconds(animDuration);

        isOpen = false;
        isAnimating = false;
    }
}