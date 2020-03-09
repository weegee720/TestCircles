using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
	public float Speed
	{
		get { return _Speed; }
		set { _Speed = value; SetDestination(_Dest); }
	}

	private float _Speed;

	private Queue<Vector3> _Waypoints = new Queue<Vector3>();

	private Vector3 _Origin;

	private Vector3 _Dest;

	private float _TotalTravelTime;

	private float _ElapsedTime;

    void Update()
    {
		if (_TotalTravelTime > 0)
		{
			_ElapsedTime += Time.deltaTime;

			transform.position = Vector3.Lerp(_Origin, _Dest, _ElapsedTime / _TotalTravelTime);

			if (_ElapsedTime >= _TotalTravelTime)
			{
				_TotalTravelTime = 0;
				_ElapsedTime = 0;
			}
		}
		else
		{
			if (_Waypoints.Count > 0)
				SetDestination(_Waypoints.Dequeue());
		}
    }

	public void AddWaypoint(Vector3 waypoint)
	{
		_Waypoints.Enqueue(waypoint);
	}

	private void SetDestination(Vector3 dest)
	{
		_Origin = transform.position;
		_Dest = dest;

		_TotalTravelTime = (_Origin - _Dest).magnitude / Speed;
		_ElapsedTime = 0;
	}
}
