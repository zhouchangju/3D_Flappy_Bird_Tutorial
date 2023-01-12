using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    [SerializeField] private float zBound;

    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver)
        {
            return;
        }
        // Time.deltaTime�������ͬˢ���ʵ����ƶ��ٶȲ�һ��������
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        if (transform.position.z <= zBound) {
            Destroy(gameObject);
        }
    }
}
