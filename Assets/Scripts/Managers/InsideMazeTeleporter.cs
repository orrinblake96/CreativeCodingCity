using UnityEngine;

namespace Managers
{
    public class InsideMazeTeleporter : MonoBehaviour
    {
        private MazeCell _currentCell;

        public void SetTeleporterLocation (MazeCell cell) {
            _currentCell = cell;
            transform.localPosition = cell.transform.localPosition;
        }
    }
}
