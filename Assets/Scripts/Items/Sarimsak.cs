using UnityEngine;

public class Sarimsak : MonoBehaviour
{
    public float damagePerSecond = 10f;
    public float auraRadius = 1.6f;

    private CircleCollider2D auraCollider;

    private void Start()
    {
        auraCollider = gameObject.AddComponent<CircleCollider2D>();
        auraCollider.isTrigger = true;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        auraCollider.radius = auraRadius / 2;

        if (collision.CompareTag("Enemy"))
        {
            EnemyHealth health = collision.GetComponent<EnemyHealth>();
            if (health != null)
            {
                health.TakeDamage(damagePerSecond * Time.deltaTime);
            }
        }
    }

    private void OnEnable()
    {
        GameObject sarimsakRenderer = transform.Find("SarimsakRenderer").gameObject;
        if (sarimsakRenderer != null)
        {
            // Sarimsak bulundu
            sarimsakRenderer.SetActive(true);
        }

        SpriteRenderer sarimsakSprite = sarimsakRenderer.GetComponent<SpriteRenderer>();
        sarimsakSprite.transform.localScale = new Vector3(auraRadius / 2, auraRadius / 2, 1) * 5f;
        sarimsakSprite.color = new Color(125f, 255f, 255f, 15f);
    }

    private void OnDisable()
    {
        GameObject sarimsakRenderer = transform.Find("SarimsakRenderer").gameObject;
        if (sarimsakRenderer != null)
        {
            sarimsakRenderer.SetActive(false);
        }
    }
}
