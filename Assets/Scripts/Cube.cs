using System.Collections;
using System.Drawing;
using UnityEngine;

[RequireComponent(typeof(Renderer))]
public class Cube : MonoBehaviour 
{
    private const string Color = "_Color";

    private Renderer _renderer;

    public bool IsLanded { get; private set; }

    private void OnEnable()
    {
        IsLanded = false;
        _renderer = GetComponent<Renderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MeshCollider collider) && IsLanded == false)
        {
            IsLanded=true;
            _renderer.material.SetColor(Color, Random.ColorHSV());
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death()
    {
        int minLifeTime = 2;
        int maxLifeTime = 6;
        WaitForSeconds waitingTime = new WaitForSeconds(Random.Range(minLifeTime, maxLifeTime));

        yield return waitingTime;
        _renderer.material.SetColor(Color, UnityEngine.Color.white);
        gameObject.SetActive(false);
    }
}
