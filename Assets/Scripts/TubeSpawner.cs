using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeSpawner : MonoBehaviour
{

    [SerializeField] private Tube tubePrefab;
    [SerializeField] private float spawnMaxY;
    [SerializeField] private float spawnMinY;
    // ��λ����
    [SerializeField] private float spawnTime;
    [SerializeField] private GameManager gameManager;

    float timer = 0f;

    // Start is called before the first frame update
    void Start()
    {
        // SpawnTube();
    }


    private void SpawnTube() {
        // x��z���䣬y��������߶����
        Vector3 spawnPos = new Vector3(transform.position.x, Random.Range(spawnMinY, spawnMaxY), transform.position.z);
        Instantiate(tubePrefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOver)
        {
            return;
        }
        timer += Time.deltaTime;
        if (timer >= spawnTime) {
            timer = 0f;
            SpawnTube();
        }
    }
}
