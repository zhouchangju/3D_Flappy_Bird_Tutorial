using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    [SerializeField] private float moveSpeed;
    [SerializeField] private float zBound;
    [SerializeField] private float zOffset;
    [SerializeField] private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver)
        {
            return;
        }
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);
        if (transform.position.z <= zBound) {
            transform.position += new Vector3(0, 0, zOffset);
        }
    }
}
