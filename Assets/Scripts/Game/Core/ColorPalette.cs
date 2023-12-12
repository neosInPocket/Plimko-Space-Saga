using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ColorPalette : MonoBehaviour
{
	[SerializeField] private ColorButton colorButtonPrefab;
	[SerializeField] private PieceColors pieceColors;
	[SerializeField] private TemporaryColorViewer colorViewer;
	[SerializeField] private PieceColoring pieceColoring;
	private List<Color> allColors => pieceColors.Colors;
	private List<ColorButton> buttons;
	
	private void Start()
	{
		for (int i = 0; i < allColors.Count; i++)
		{
			var button = Instantiate(colorButtonPrefab, transform);
			button.OnClicked += OnButtonClicked;
			buttons.Add(button);
		}
		
		colorViewer.Color = pieceColors.DefaultColor;
	}
	
	private void OnButtonClicked(ColorButton button)
	{
		pieceColoring.CurrentColor = button.CurrentButtonColor;
		colorViewer.Color = button.CurrentButtonColor;
	}
}
