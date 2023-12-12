using System.Collections.Generic;
using UnityEngine;

public class MainObjectSpawner : MonoBehaviour
{
	[SerializeField] private Vector2 yBorders;
	[SerializeField] private Vector2 xBorders;
	[SerializeField] private int rowsAmount;
	[SerializeField] private int zoneCount;
	[SerializeField] private Transform zoneContainer;
	[SerializeField] private Transform piecesContainer;
	[SerializeField] private Piece piece;
	[SerializeField] private FloatingZoneController triggerZone;
	[SerializeField] private PieceColors pieceColors;
	[SerializeField] private Camera canvasCamera;
	private List<Piece> pieces;
	private List<FloatingZoneController> zones;
	private Vector2 screenSize;


	private void Start()
	{
		pieces = new List<Piece>();
		screenSize = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));

		CreatePyramid();
	}

	private void CreatePyramid()
	{
		Vector2 verticalSize = new Vector2(2 * screenSize.y * yBorders.x - screenSize.y, 2 * screenSize.y * yBorders.y - screenSize.y);
		Vector2 horizontalSize = new Vector2(2 * screenSize.x * xBorders.x - screenSize.x, 2 * screenSize.x * xBorders.y - screenSize.x);

		float verticalStep = (verticalSize.y - verticalSize.x) / (rowsAmount - 1);
		float horizontalStep = (horizontalSize.y - horizontalSize.x) / (rowsAmount - 1);

		Vector2 piecePosition = Vector2.zero;
		piecePosition.x = horizontalSize.x;

		for (int i = 0; i < rowsAmount; i++)
		{
			piecePosition.y = verticalSize.x + verticalStep * i;

			for (int j = rowsAmount - i; j > 0; j--)
			{
				pieces.Add(Instantiate(piece, piecePosition, Quaternion.identity, piecesContainer));
				piecePosition.x += horizontalStep;
			}

			piecePosition.x = horizontalSize.x + (i + 1) * horizontalStep / 2;

			if (i == rowsAmount - 1)
			{
				continue;
			}
		}

		float zoneWidth = 2 * (xBorders.y - xBorders.x) * screenSize.x / zoneCount;
		float zoneHeight = 2 * (yBorders.y - yBorders.x) * screenSize.y;

		for (int i = 0; i < zoneCount; i++)
		{
			float allZonesWidth = zoneWidth * zoneCount;
			float zoneX = 2 * xBorders.x * screenSize.x - screenSize.x + allZonesWidth / zoneCount / 2 * (2 * i + 1);
			float zoneY = 2 * yBorders.x * screenSize.y - screenSize.y + zoneHeight / 2;
			Vector2 zonePosition = new Vector2(zoneX, zoneY);
			FloatingZoneController zone = Instantiate(triggerZone, zonePosition, Quaternion.identity, zoneContainer);
			zone.InnerCanvas.worldCamera = canvasCamera;
			zone.Size = new Vector2(zoneWidth, zoneHeight);
			zone.CurrentColor = pieceColors.Colors[i];
		}
	}


}