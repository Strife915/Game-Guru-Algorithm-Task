using System.Collections.Generic;
using UnityEngine;

namespace GameGuruGridTask.Grids
{
    public class GridManager : MonoBehaviour
    {
        public GridCreator gridCreator;
        public static GridManager instance;
        public int clickedObjectCount = 0;

        void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
                return;
            }

            instance = this;
        }

        public void HandleClick(GridObject clickedObject)
        {
            clickedObjectCount++;
            if (clickedObjectCount >= 3)
                CheckGridObjectNeighboursDfs(clickedObject);
        }

        void CheckGridObjectNeighboursDfs(GridObject startObject)
        {
            var stack = new Stack<GridObject>();
            var visited = new HashSet<GridObject>();

            stack.Push(startObject);

            while (stack.Count > 0)
            {
                var currentObject = stack.Pop();

                TryPushToStackAndAddToVisited(gridCreator.GetGridObjectAt(currentObject.gridPosition.X, currentObject.gridPosition.Y + 1), stack, visited);
                TryPushToStackAndAddToVisited(gridCreator.GetGridObjectAt(currentObject.gridPosition.X, currentObject.gridPosition.Y - 1), stack, visited);
                TryPushToStackAndAddToVisited(gridCreator.GetGridObjectAt(currentObject.gridPosition.X + 1, currentObject.gridPosition.Y), stack, visited);
                TryPushToStackAndAddToVisited(gridCreator.GetGridObjectAt(currentObject.gridPosition.X - 1, currentObject.gridPosition.Y), stack, visited);
            }

            if (visited.Count > 2)
            {
                foreach (var o in visited)
                    o.ResetObject();
                visited.Clear();
            }
        }

        void TryPushToStackAndAddToVisited(GridObject neighbor, Stack<GridObject> stack, HashSet<GridObject> visited)
        {
            if (neighbor != null && !visited.Contains(neighbor) && neighbor.Clicked)
            {
                stack.Push(neighbor);
                visited.Add(neighbor);
            }
        }
    }
}