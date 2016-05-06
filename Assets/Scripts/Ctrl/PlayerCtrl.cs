using UnityEngine;
using System.Collections;

public class PlayerCtrl : MonoBehaviour
{
    Animator animator;
    public float speed;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow) || 
            Input.GetKey(KeyCode.DownArrow) || 
            Input.GetKey(KeyCode.LeftArrow) || 
            Input.GetKey(KeyCode.RightArrow))
            Move();
        else
            animator.SetBool("bWalk", false);
    }

    void Move () {
        animator.SetBool("bWalk", true);
        float amtMove = speed * Time.smoothDeltaTime;
        float keyHorizontal = Input.GetAxis("Horizontal");
        float keyVertical = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right * amtMove * keyHorizontal, Space.World);
        transform.Translate(Vector3.forward * amtMove * keyVertical, Space.World);
    }
}
