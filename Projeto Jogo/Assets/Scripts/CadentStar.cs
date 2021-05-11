using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CadentStar : MonoBehaviour
{

    private Animator animator;
    private bool big;
    private bool shootable;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        big = false;
        shootable = true;
        animator.Play("dead");
    }

    // Update is called once per frame
    void Update()
    {
        if (shootable)
        {
            shootable = false;
            StartCoroutine(SpawnStar());
        }
    }

    IEnumerator SpawnStar()
    {

        yield return new WaitForSeconds(Random.Range(1,6));

        if (big)
        {
            animator.SetTrigger("shootBig");
            big = false;
        }
        else
        {
            animator.SetTrigger("shootSmall");
            big = true;
        }

        shootable = true;
    }
}
