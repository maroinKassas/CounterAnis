using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    private const float SPEED = 40.0f;
    private int angle = 45;
    private Animator animator;
    private GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        prefab = Resources.Load("bullet") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            GameObject bullet = Instantiate(prefab) as GameObject;

            angle *= -1;
            bullet.transform.rotation = Quaternion.Euler(0, 0, angle);

            bullet.transform.position = transform.position + Camera.main.transform.forward * 2;
            Rigidbody bulletRigidbody = bullet.GetComponent<Rigidbody>();
            bulletRigidbody.velocity = Camera.main.transform.forward * SPEED;

            StartCoroutine(Die());
        }
        else
        {
            animator.SetBool("attack", false);
        }
    }

    private IEnumerator Die()
    {
        // Play the animation for getting suck in
        animator.SetBool("attack", true);
        yield return new WaitForSeconds(2);
        // Move this object somewhere off the screen

    }
}
