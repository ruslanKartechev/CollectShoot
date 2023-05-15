using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameCore.Data
{
    // [CreateAssetMenu(fileName = nameof(ScriptableObject), menuName = "SO/" + nameof(ScriptableObject))]
    public class DataByName<TName,TData> : ScriptableObject where TName : ScriptableObject where TData : class
    {
        public List<Data<TName, TData>> data = new List<Data<TName, TData>>();

        public TData GetContent(TName name)
        {
            return data.FirstOrDefault(t => t.name == name).content;
        }
        
        [System.Serializable]
        public class Data<A,B>
        {
            public A name;
            public B content;
        }
    }
}