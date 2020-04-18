using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class AttackController : MonoBehaviour
{
    private const float BULLET_POSITION_Y = 1.0f;
    private const float COOLDOWN_ATTACK_TIME = 0.75f;
    private const float COOLDOWN_CHARGED_ATTACK_TIME = 0.1f;
    private const float SPEED = 100.0f;
    private const float SPEED_ROTATION = 20.0f;

    private float attackTime = 0f;
    private float chargedAttackTime = 0f;

    [SerializeField]
    Text countDownAttackText, countDownChargedAttackText;

    private Animator animator;
    private GameObject prefab;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        prefab = Resources.Load("Bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        DisplayCoolDown(attackTime, COOLDOWN_ATTACK_TIME, countDownAttackText);
        DisplayCoolDown(chargedAttackTime, COOLDOWN_CHARGED_ATTACK_TIME, countDownChargedAttackText);
        StartCoroutine(Attacking());
    }

    private void DisplayCoolDown(float time, float coolDown, Text text)
    {
        if (time <= 0)
        {
            text.gameObject.SetActive(false);
        }
        else
        {
            text.gameObject.SetActive(true);
            text.text = time.ToString("0.0");
        }
    }

    private IEnumerator Attacking()
    {
        if (Input.GetKey(KeyCode.Mouse0) && attackTime <= 0)
        {
            animator.SetBool("attack", true);
            attackTime = COOLDOWN_ATTACK_TIME;

            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            animator.SetBool("attack", false);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse1) && chargedAttackTime <= 0)
        {
            animator.SetBool("chargedAttack", true);
            chargedAttackTime = COOLDOWN_CHARGED_ATTACK_TIME;

            yield return new WaitForSeconds(animator.GetCurrentAnimatorStateInfo(0).length);

            GameObject bullet = Instantiate(prefab) as GameObject;

            bullet.transform.position = new Vector3(0, BULLET_POSITION_Y, 0) + transform.position + Camera.main.transform.forward;
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = Camera.main.transform.forward * SPEED;
            bulletRigidbody.angularVelocity = new Vector3(0, Mathf.PI * SPEED_ROTATION, 0);

            PlayerStats playerStats = gameObject.GetComponent<PlayerStats>();
            bullet.GetComponent<BulletStats>().SetDamage(playerStats.GetHealth());

            animator.SetBool("chargedAttack", false);
        }
        else
        {
            attackTime -= 1 * Time.deltaTime;
            chargedAttackTime -= 1 * Time.deltaTime;
        }
    }
}
