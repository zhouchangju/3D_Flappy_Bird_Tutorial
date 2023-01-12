using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    // SerializeField + private��ʹ������ڱ༭���г��֣����ǲ��ᱻ����ʹ�õ�
    // С��ĸ��壬�˶����ǲٿظ��壬�����ǲٿ�ģ�ͱ���
    [SerializeField] private Rigidbody birdRigidbody;

    // ��Ծ�ĸ߶�
    [SerializeField] private float jumpForce;

    [SerializeField] private Animator birdAnimator;

    [SerializeField] private GameManager gameManager;


    [SerializeField] private GameObject crashSmoke;

    // ��Ч
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip addSound;
    [SerializeField] private AudioClip crashSound;


    // ��������
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
        // �л�����״̬
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
     * ����������
     */
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Tube")) {
            gameManager.AddScore();
            audioSource.PlayOneShot(addSound);
        }
    }

    /**
     * ��ײ���ذ����ˮ��
     */ 
    private void OnCollisionEnter(Collision collision)
    {
        gameManager.SetGameOver();


        audioSource.PlayOneShot(crashSound);


        Instantiate(crashSmoke, transform.position, Quaternion.identity);

        // �����ٷ��ˣ����ǿ��Ե���
        birdAnimator.SetBool("isFly", false);
        birdAnimator.SetBool("isFall", true);
    }

   
}
