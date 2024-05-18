using System.Collections;
using UnityEngine;

public class Spawner : Pool
{
    private float _radius = 10f;

    private void Start()
    {
        Initialize();
        StartCoroutine(SetCubes());
    }

    private IEnumerator SetCubes()
    {
        WaitForSeconds waitingTime = new WaitForSeconds(0.5f);

        while (true)
        {
            if (TryGetCube(out Cube cube))
            {
                cube.gameObject.SetActive(true);
                Vector3 newPosition = transform.position + Random.insideUnitSphere * _radius;
                cube.transform.position = new Vector3(newPosition.x, transform.position.y, newPosition.z);
            }

            yield return waitingTime;
        }
    }
}
