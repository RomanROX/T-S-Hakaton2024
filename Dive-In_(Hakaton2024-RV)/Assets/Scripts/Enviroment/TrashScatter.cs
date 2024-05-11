using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashScatter : MonoBehaviour
{
    [Header("SpawnerProperties")]
    [SerializeField] int numOfTrash;
    [SerializeField] float instancingDelay;
    [Space]
    [SerializeField] GameObject[] trashToSpawn;
    [Space]
    [SerializeField] GameObject point1;
    [SerializeField] GameObject point2;

    // Start is called before the first frame update
    void Start()
    {
        StartSpawning();
    }


    void StartSpawning()
    {
        for (int i = 0; i < numOfTrash; i++)
        {
            StartCoroutine(SpawningWithDelay());
            Debug.Log("Spawned " + i);
        }
    }

    private IEnumerator SpawningWithDelay()
    {
        yield return new WaitForSeconds(instancingDelay);
        Instantiate(trashToSpawn[Random.Range(0, trashToSpawn.Length)].gameObject, RandomPosition(), Random.rotation);
    }

    private Vector3 RandomPosition()
    {
        //return random pos between two points
        Vector3 newPosition = new Vector3(Random.Range(point1.transform.position.x, point2.transform.position.x),
                                        Random.Range(point1.transform.position.y, point2.transform.position.y),
                                        Random.Range(point1.transform.position.z, point2.transform.position.z));
        return newPosition;
    }
}
