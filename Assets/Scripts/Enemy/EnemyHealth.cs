using TMPro;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private TextMeshPro healthText;

    public float health = 100f;

    private void Start()
    {
        healthText = GetComponentInChildren<TextMeshPro>();
        healthText.alignment = TextAlignmentOptions.Center;
    }

    private void Update()
    {
        healthText.text = Mathf.CeilToInt(health).ToString();
    }

    public void TakeDamage(float damageAmount)
    {
        health -= damageAmount;
        StartCoroutine(DamageEffect());
        if (health <= 0f)
        {
            Die();
        }
    }

    private void Die()
    {
        EnemyPool.Instance.ReturnEnemy(gameObject);
    }

    System.Collections.IEnumerator DamageEffect()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
        }
    }
}
