using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Pool : MonoBehaviour
{
    [SerializeField] private Cube _prefab;
    [SerializeField] private int _capacity;

    private List<Cube> _pool = new List<Cube>();

    protected void Initialize()
    {
        for (int i = 0; i < _capacity; i++)
        {
            _pool.Add(InstantiateCube());
        }
    }

    protected bool TryGetCube(out Cube cube)
    {
        cube = _pool.FirstOrDefault(p => p.gameObject.activeSelf == false);

        return cube != null;
    }

    private Cube InstantiateCube()
    {
        Cube newCube = Instantiate(_prefab, transform);
        newCube.gameObject.SetActive(false);

        return newCube;
    }
}
