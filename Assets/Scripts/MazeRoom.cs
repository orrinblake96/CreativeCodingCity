using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeRoom : ScriptableObject
{
    public int settingsIndex;
    public MazeRoomSettings settings;
    
    private List<MazeCell> _cells = new List<MazeCell>();

    public void Add(MazeCell cell)
    {
        cell.room = this;
        _cells.Add(cell);
    }
    
    public void Assimilate (MazeRoom room) {
        for (int i = 0; i < room._cells.Count; i++) {
            Add(room._cells[i]);
        }
    }
}
