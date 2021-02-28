using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LivesScript : MonoBehaviour
{
    public GameObject[] lives;
    public int life;

    private bool dead;

    float dmgCooldown = 5f;
    private bool invulnerable = false;

    void Start()
    {
        life = lives.Length;
    }

    void Update()
    {
        if (life == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
    }

     public void TakeDamage (int damage) 
    {
        if(!invulnerable)
        {
            life -= damage;
            Destroy(lives[life].gameObject);
            StartCoroutine(JustHit());
        }
    }

    IEnumerator JustHit()
    {
        invulnerable = true;
        yield return new WaitForSeconds(dmgCooldown);
        invulnerable = false;
    }
}
