using System.Collections;
using System.Collections.Generic;
using RecyclerView.core;
using RecyclerView.data;
using UnityEngine;

public abstract class BaseDataProvider : MonoBehaviour,IDataProvider
{

    public List<CellData> DataSource = new List<CellData>();
   
    public BaseRecyclerView BaseRecyclerView;

    public abstract int GetCellCount();
    public abstract void SetCell(GameObject cell, int index);


   // DataSource Change  dependency sub class implement

   public void DataSourceChange()
   {
       if (null == BaseRecyclerView)
       {
           return;
       }
       
       BaseRecyclerView.RefreshData();
   }
   
   
  
   
   
}
