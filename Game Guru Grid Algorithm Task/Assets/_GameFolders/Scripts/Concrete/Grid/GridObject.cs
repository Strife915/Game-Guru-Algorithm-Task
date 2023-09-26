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
            _clicked = !_clicked;
            if (_clicked)
                GridManager.instance.HandleClick(this);
            if (!_clicked)
                GridManager.instance.clickedObjectCount--;
            ChangeImageColor();
        }

        void ChangeImageColor()
        {
            gridImage.color = _clicked ? Color.green : Color.blue;
        }

        public void ResetObject()
        {
            _clicked = false;
            gridImage.color = Color.blue;
        }
    }
}