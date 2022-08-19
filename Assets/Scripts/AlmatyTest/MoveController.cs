using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [SerializeField]
    private  LayerMask _layerMask;
    [SerializeField] 
    private GameObject _gameOverScreen;
    
    private Queue<Vector3> _points;
    private Vector3 _nextPoint;
    private float _step;
    private LineRenderer _lr;
    
    public float speed;

    void Awake()
    {
        _lr = GetComponent<LineRenderer>();
        _points = new Queue<Vector3>();
        _nextPoint = transform.position;
        _lr.positionCount = 1;
        _lr.SetPosition(_lr.positionCount - 1,Vector3.zero);
    }
    
    void Update()
    {
        _step = speed * Time.deltaTime;
        if (Vector3.Distance(transform.position, _nextPoint) < 0.05f && _points.Count != 0)
        {
            _nextPoint = _points.Dequeue();
        }
        if (Vector3.Distance(transform.position, _nextPoint) > 0.05f)
            transform.position = Vector3.MoveTowards(transform.position, _nextPoint, _step);
    }
    public void AddPoint()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit raycastHit, float.MaxValue, _layerMask ))
        {
            Vector3 pos = new Vector3(raycastHit.point.x, 0, raycastHit.point.z);
            _points.Enqueue(pos);
            _lr.positionCount++;
            _lr.SetPosition(_lr.positionCount-1,pos);
            
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Spike"))
        {
            _gameOverScreen.SetActive(true);
        }
    }
}
