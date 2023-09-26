using UnityEngine;

namespace GameGuruGridTask.Grids
{
    public class GridCreator : MonoBehaviour
    {
        bool _isPortrait;

        [Tooltip("Should be greater than 3, if you enter less than 3 it will automatically set to 3")]
        public int size;

        public GridObject gridObjectPrefab;
        public RectTransform gridPanelRectTransform;
        public GridObject[,] gridObjects;
        public float Offset;

        void Awake()
        {
            CheckSize();
            SetGridPanelTransform();
            CreateGrid();
        }


        void SetGridPanelTransform()
        {
            var isPortrait = Screen.width < Screen.height;
            float size = isPortrait ? Screen.width : Screen.height / 2;
            var panelSize = new Vector2(size, size);
            gridPanelRectTransform.sizeDelta = panelSize;
        }

        void CreateGrid()
        {
            gridObjects = new GridObject[size, size];
            var imageSize = CalculateImageGridObjectImageSize();
            var spacing = imageSize.x + Offset;

            for (var y = 0; y < size; y++)
            for (var x = 0; x < size; x++)
            {
                var gridObject = Instantiate(gridObjectPrefab, gridPanelRectTransform);
                var rectTransform = gridObject.GetComponent<RectTransform>();
                rectTransform.sizeDelta = imageSize;
                gridObject.SetGridImageSize(imageSize);

                var xOffset = x * spacing;
                var yOffset = -y * spacing;
                rectTransform.anchoredPosition = new Vector2(xOffset, yOffset);

                gridObject.SetGridPosition(x, y);
                gridObjects[x, y] = gridObject;
            }
        }


        Vector2 CalculateImageGridObjectImageSize()
        {
            var spacing = Offset * (size - 1);
            var panelSize = gridPanelRectTransform.sizeDelta - new Vector2(spacing, spacing);
            return panelSize / size;
        }

        void CheckSize()
        {
            if (size < 3)
                size = 3;
        }
    }
}