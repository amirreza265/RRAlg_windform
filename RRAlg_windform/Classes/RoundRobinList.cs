using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlg_windform.Classes
{
    public delegate void Func<in T1, in T2, in T3>(T1 t1, T2 t2, T3 t3);
    public class RoundRobinList<T>
    {
        private Queue<RRItem<T>> Items;

        public int Quantom { get; set; } = 1;

        public event Func<int, RRItem<T>, bool> OnGetNext;

        public ulong Tick { get; private set; }

        public int Count => Items.Count;

        public RoundRobinList()
        {
            Items = new Queue<RRItem<T>>();
            OnGetNext = (q, item, removed) => { };
        }

        public RRItem<T> AddItem(T item, int time = 1)
        {
            var rrItem = new RRItem<T>(item, time)
            {
                LastUpadateTime = Tick,
                TotalWaitingTime = 0
            };

            Items.Enqueue(rrItem);

            return rrItem;
        }

        public List<T?> GetAllData()
        {
            return Items?.Select(i => i.Data).ToList();
        }

        public List<RRItem<T>> GetAllItems()
        {
            return Items.ToList();
        }

        //public void AddRange(IEnumerable<T> values)
        //{
        //    foreach (var val in values)
        //    {
        //        Items.Enqueue(new RRItem<T>(val));
        //    }
        //}

        public void Clear()
        {
            Items.Clear();
            Tick = 0;
        }
        public T? GetNext()
        {
            if (Items.Count <= 0)
                return default;

            var item = Items.Dequeue();

            var startTime = Tick;
            int w = Quantom;
            bool remove = false;

            if (item.Weight > Quantom)
            {
                Tick += (ulong)Quantom;
                item.DecreaseWeight(Quantom);
            }
            else if (item.Weight > 0)
            {
                w = item.Weight;
                remove = true;

                Tick += (uint)w;
                item.DecreaseWeight(item.Weight);
            }

            item.TotalWaitingTime += (startTime - item.LastUpadateTime);
            item.LastUpadateTime = Tick;

            OnGetNext(w, item, remove);

            if (item.Weight > 0)
                Items.Enqueue(item);

            return item.Data;
        }
    }
}
