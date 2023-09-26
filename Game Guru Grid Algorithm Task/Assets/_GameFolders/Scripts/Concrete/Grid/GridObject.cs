using UnityEngine;
using UnityEngine.UI;

namespace GameGuruGridTask.Grids
{
    public class GridObject : MonoBehaviour
    {
        public GridStruct gridPosition;
        public Image gridImage;

        public void SetGridPosition(int x, int y)
        {
            gridPosition = new GridStruct(x, y);
        }

        public GridStruct GetGridPosition()
        {
            return gridPosition;
        }

        public void SetGridImageSize(Vector2 newSize)
        {
            gridImage.rectTransform.sizeDelta = newSize;
        }

        public void OnClickEvent()
        {
            Debug.Log(gridPosition.X + " " + gridPosition.Y);
        }
    }
}