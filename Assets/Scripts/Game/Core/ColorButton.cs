using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
	[SerializeField] Image buttonImageColor;
	[SerializeField] private Button button;
	public Button Button => button;
	public Action<ColorButton> OnClicked;
	
	public Color CurrentButtonColor
	{
		get => currentColor;
		set
		{
			currentColor = value;
			buttonImageColor.color = value;
		}
	}
	
	private Color currentColor;
	
	private void Start()
	{
		button.onClick.AddListener(ButtonClicked);
	}
	
	private void ButtonClicked()
	{
		OnClicked?.Invoke(this);
	}
}
