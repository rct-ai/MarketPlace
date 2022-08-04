using System.Collections.Generic;
using RecyclerView.data;
using UnityEngine;
using UnityEngine.UI;

namespace RecyclerView.core
{   
    
    public enum EScrollDirect {
        Vertical,
        Horizontal
    }
    
    public class ViewRectCell {
        public RectTransform Item;
        public int Index;
    }


    public  abstract class BaseRecyclerView : ScrollRect
    {   
        
        
        
        public IDataProvider DataProvider;
        
        public Vector2 Padding;
        public Vector2 Margin;
        public bool IsGrid;
        public int Segment = 1;
        public RectTransform CellPrefab;
        public EScrollDirect Direction;
      

        private RecyclerViewManager _recyclerViewManager;
        
        
         
       // 想要实现筛选功能 也就是说数据源发生变换时将刷新  UI
       // Reload 将让 Manager 重新加载列表数据   goes to 保证了这个过程将使用新数据
       // 外部数据源的改变定义在 DataProvider 的实现上即可
       
       
        public void StartLoading(IDataProvider dataProvider) {
            DataProvider = dataProvider;
            ReloadData();
        }
        
        
        // when data source chane ...
        public  void RefreshData()
        {
            if (null == DataProvider)
            {
                // debug need bind data provider first
                return;
            }
            
            ReloadData();
        }
        
      
        private  void ReloadData() {
            if (DataProvider == null) {
                if (Application.isPlaying) {
                    // debug
                }
              
                return;
            }

            StopMovement();
            vertical = Direction ==  EScrollDirect.Vertical;
            horizontal = Direction == EScrollDirect.Horizontal;
            if (_recyclerViewManager == null) {
                _recyclerViewManager= new RecyclerViewManager();
            }
            
            
            _recyclerViewManager.OnMeasure(this);
            onValueChanged.RemoveListener(_OnValueChanged);
            _recyclerViewManager.DoStart();
            onValueChanged.AddListener(_OnValueChanged);
        }
        
        private void _OnValueChanged(Vector2 normalizedPos) {
            _recyclerViewManager.OnValueChanged();
        }

      
        
        
    }
    
    
}

