using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{
	[SerializeField]
	private GameplayUI _GameplayUI;

	[SerializeField]
	private Ball _Ball;

	private Camera _Camera;

	private float _TopBorder;
	private float _BottomBorder;
	private float _LeftBorder;
	private float _RightBorder;

	public void Start()
	{
		_Camera = Camera.main;

		Vector3 bottomLeftCorner = _Camera.ViewportToWorldPoint(new Vector3(0, 0, 0));
		Vector3 topRightCorner = _Camera.ViewportToWorldPoint(new Vector3(1, 1, 0));

		_TopBorder = topRightCorner.y;
		_RightBorder = topRightCorner.x;

		_BottomBorder = bottomLeftCorner.y;
		_LeftBorder = bottomLeftCorner.x;

		_Ball.Speed = _GameplayUI.SpeedSliderValue;
	}

	public void OnEnable()
	{
		_GameplayUI.OnSpeedSliderChange += GameplayUI_OnSpeedSliderValueChange;
		_GameplayUI.OnScreenClick += GameplayUI_OnScreenClick;
	}

	public void OnDisable()
	{
		_GameplayUI.OnSpeedSliderChange -= GameplayUI_OnSpeedSliderValueChange;
		_GameplayUI.OnScreenClick -= GameplayUI_OnScreenClick;
	}

	private void GameplayUI_OnSpeedSliderValueChange(float speed)
	{
		_Ball.Speed = speed;
	}

	private void GameplayUI_OnScreenClick(Vector3 position)
	{
		Vector3 worldPos = _Camera.ScreenToWorldPoint(new Vector3(position.x, position.y, _Camera.nearClipPlane));
		worldPos.z = 0;

		if (worldPos.x > _LeftBorder && worldPos.x < _RightBorder &&
			worldPos.y > _BottomBorder && worldPos.y < _TopBorder)
		_Ball.AddWaypoint(worldPos);
	}
}
