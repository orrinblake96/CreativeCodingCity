using UnityEngine;

namespace Managers
{
    public class TimeReducerLoactions : MonoBehaviour
    {
        private MazeCell _currentCell;

        public void SetTimeReducerLocations (MazeCell cell) {
            _currentCell = cell;
            transform.localPosition = cell.transform.localPosition + Vector3.up/2;
        }
    }
}
