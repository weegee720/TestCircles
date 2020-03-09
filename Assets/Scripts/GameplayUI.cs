using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;

public class GameplayUI : MonoBehaviour
{
	public event Action<float> OnSpeedSliderChange = delegate { };

	public event Action<Vector3> OnScreenClick = delegate { };

	[SerializeField]
	private Slider _SpeedSlider;

	[SerializeField]
	private Text _SpeedText;

	public float Speed
	{
		get
		{
			if (_SpeedSlider)
				return _SpeedSlider.value;
			return 0;
		}
	}

	private void Start()
	{
		UpdateSpeedText();
	}

	private void Update()
	{
		if (!EventSystem.current.IsPointerOverGameObject())
		{
			if (Input.GetMouseButtonUp(0))
			{
				OnScreenClick(Input.mousePosition);
			}
		}
	}

	private void UpdateSpeedText()
	{
		_SpeedText.text = Mathf.Floor(_SpeedSlider.value).ToString();
	}

	public float SpeedSliderValue
	{
		get { return _SpeedSlider.value; }
	}

	public void SpeedSlider_OnValueChange(float newValue)
	{
		UpdateSpeedText();
		OnSpeedSliderChange(newValue);
	}

	public void BackButton_OnClick()
	{
		SceneManager.LoadScene("Menu", LoadSceneMode.Single);
	}
}
