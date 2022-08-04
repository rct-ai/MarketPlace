using UnityEngine;

namespace RecyclerView.data
{
    public interface IDataProvider
    {
        int GetCellCount();
        
        void SetCell(GameObject cell, int index);
    }
    
    
}


