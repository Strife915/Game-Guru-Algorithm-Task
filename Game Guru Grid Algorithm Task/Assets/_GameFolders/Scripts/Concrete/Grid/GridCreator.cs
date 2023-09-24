using UnityEngine;

namespace GameGuruGridTask.Grids
{
    public class GridCreator : MonoBehaviour
    {
        [Tooltip("Should be greater than 1")]
        [SerializeField] int _size;
        [SerializeField] GameObject _gridObjectPrefab;
        [SerializeField] RectTransform _gridPanelRectTransform;
        GridObject[,] _gridObjects;
        void Awake()
        {
            GenerateGrid();
            // Debug.Log(Screen.width);
            // Debug.Log(Screen.height);
            // float screenWidth = Screen.width;
            // float screenHeight = Screen.height;
            // float cellSize = Mathf.Min(screenWidth, screenHeight) / (_size * 2);
            // Debug.Log(cellSize);
        }

        void GenerateGrid()
        {
            SetGridPanelTransform();
            // _gridObjects = new GridObject[_size,_size];
            // for (int x = 0; x < _size; x++)
            // {
            //     for (int z = 0; z < _size; z++)
            //     {
            //         GridStruct gridPosition = new GridStruct(x, z);
            //         _gridObjects[x,z] = new GridObject(gridPosition);
            //     } 
            // }
        }

        void SetGridPanelTransform()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            Vector2 panelSize = new Vector2(screenWidth, screenHeight / 2);
            _gridPanelRectTransform.sizeDelta = panelSize;

            float yOffset = 75f;
            Vector3 panelPosition = new Vector3(0, (screenHeight / 4) - yOffset, 0);
            _gridPanelRectTransform.localPosition = panelPosition;
        }

    }
}