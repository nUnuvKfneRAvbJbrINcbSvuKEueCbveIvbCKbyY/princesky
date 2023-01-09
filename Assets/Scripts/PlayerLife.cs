using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool inCollision = false;

    [SerializeField] private AudioSource deathSoundEffect;
    [SerializeField] private GameObject[] hearths;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            inCollision = true;

            Damage();

            StartCoroutine(Dps());

            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            inCollision = false;
        }
    }

    IEnumerator Dps()
    {
        yield return new WaitForSeconds(0.5f);

        if (inCollision)
        {
            Damage();
            StartCoroutine(Dps());
        }

        StopCoroutine(Dps());
    }

    private void Damage()
    {
        hearths.Where(x => x.activeSelf).FirstOrDefault().SetActive(false);

        if (hearths.All(x => !x.activeSelf))
        {
            Die();
        }
    }

    public void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
