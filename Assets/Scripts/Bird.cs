using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // SerializeField + private，使其可以在编辑器中出现，但是不会被其他使用到
    // 小鸟的刚体，运动就是操控刚体，而不是操控模型本身
    [SerializeField] private Rigidbody birdRigidbody;

    // 跳跃的高度
    [SerializeField] private float jumpForce;

    [SerializeField] private Animator birdAnimator;

    [SerializeField] private GameManager gameManager;


    [SerializeField] private GameObject crashSmoke;

    // 音效
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip addSound;
    [SerializeField] private AudioClip crashSound;


    // 背景音乐
    [SerializeField] private AudioSource backgroundAudioSource;
    [SerializeField] private AudioClip backgroundSound;

    // Start is called before the first frame update
    void Start()
    {
        backgroundAudioSource.PlayOneShot(backgroundSound);
    }

    // Update is called once per frame
    void Update()
    {

        if (gameManager.IsGameOver) {
            return;
        }

        if (Input.GetKeyDown(KeyCode.Space)) {
            birdRigidbody.velocity = Vector3.up * jumpForce;       
        }
        // 切换动画状态
        if (birdRigidbody.velocity.y > 0)
        {
            birdAnimator.SetBool("isFly", true);
            birdAnimator.SetBool("isFall", false);
        }
        else {
            birdAnimator.SetBool("isFly", false);
            birdAnimator.SetBool("isFall", true);
        }
    }

    /**
     * 碰到触发器
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tube")) {
            gameManager.AddScore();
            audioSource.PlayOneShot(addSound);
        }
    }

    /**
     * 碰撞到地板或者水管
     */ 
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.SetGameOver();


        audioSource.PlayOneShot(crashSound);


        Instantiate(crashSmoke, transform.position, Quaternion.identity);

        // 不能再飞了，但是可以掉落
        birdAnimator.SetBool("isFly", false);
        birdAnimator.SetBool("isFall", true);
    }

   
}
