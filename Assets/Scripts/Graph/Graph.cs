using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Graph : MonoBehaviour
{
    [SerializeField] Transform _pointCubePrefab;
    [SerializeField] int _curveResolution = 10;

    Transform[] points;

    void Awake()
    {
        Vector3 position = Vector3.zero;
        
        int index = 0;
        float divider = 5f;
        var step = 2f / _curveResolution;
        var localScale = Vector3.one * step;

        points = new Transform[_curveResolution];

        while ( index < _curveResolution)
        {
            var _currentPoint = Instantiate(_pointCubePrefab, transform);
            
            points[index] = _currentPoint;
            
            //var renderer = _currentPoint.GetComponent<Renderer>();
            //var randColor = new Color(Random.Range(0, 254), Random.Range(0, 254), Random.Range(0, 254));
           // renderer.material.SetColor("_BaseColor", randColor);
           
            position.x = (index + 0.5f) * step - 1f;
          //  position.y = position.x * position.x * position.x;

            _currentPoint.localPosition = position;
            _currentPoint.localScale = localScale;
            index++;
        }
    }

    void Update()
    {
        for (int i = 0; i < points.Length; i++)
        {
            var currentPoint = points[i];
            var currentPosition = currentPoint.localPosition;
            currentPosition.y = Mathf.Sin(Mathf.PI * (currentPosition.x * Time.time));

            currentPoint.position = currentPosition;

        }
    }
}
