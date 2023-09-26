using System;
using UnityEngine;
using UnityEngine.UI;

namespace GameGuruGridTask.Grids
{
    public class GridObject : MonoBehaviour
    {
        public GridStruct gridPosition;
        public Image gridImage;
        bool _clicked;
        public bool Clicked => _clicked;

        void Start()
        {
            gridImage.color = Color.blue;
        }

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
            _clicked = !_clicked;
            ChangeImageColor();
        }

        void ChangeImageColor()
        {
            gridImage.color = _clicked ? Color.green : Color.blue;
        }
    }
}