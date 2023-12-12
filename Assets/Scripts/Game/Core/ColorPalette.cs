using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorPalette : MonoBehaviour
{
	[SerializeField] private PieceColors pieceColors;
	[SerializeField] private TemporaryColorViewer colorViewer;
	[SerializeField] private PieceColoring pieceColoring;
	[SerializeField] private List<ColorButton> buttons;
	private List<Color> allColors => pieceColors.Colors;


	private void Start()
	{
		for (int i = 0; i < 3; i++)
		{
			buttons[i].OnClicked += OnButtonClicked;
			buttons[i].CurrentButtonColor = pieceColors.Colors[i];
		}
	}

	private void OnButtonClicked(ColorButton button)
	{
		pieceColoring.CurrentColor = button.CurrentButtonColor;
		colorViewer.Color = button.CurrentButtonColor;
	}
}
