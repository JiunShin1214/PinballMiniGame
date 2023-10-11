using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.VFX;

public class Map : MonoBehaviour
{
    public GameObject[] prefabs;

    private BoxCollider area;
    public int count;

    private List<GameObject> gameObject = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        count = Random.Range(0, 10);
        area = GetComponent<BoxCollider>();
        for(int i=0; i<count; ++i)
        {
            spawn();
        }
        area.enabled = false;
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 basePosition = transform.position;
        Vector3 size = area.size;

        float posX = basePosition.x + Random.Range(-size.x / 2f, size.x / 2f);
        float posY = basePosition.y;
        float posZ = basePosition.z + Random.Range(-size.z / 2f, size.z / 2f);

        Vector3 spawnPos = new Vector3(posX, posY, posZ);
        return spawnPos;
    }


    private void spawn()
    {
        int selection = Random.Range(0, prefabs.Length);
        GameObject selectedPrefab = prefabs[selection];
        Vector3 spawnPos = GetRandomPosition();
        GameObject instance = Instantiate(selectedPrefab, spawnPos, Quaternion.identity);
        gameObject.Add(instance);
    }
    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindGameObjectsWithTag("Pin").Length<1)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
