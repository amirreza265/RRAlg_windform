using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RRAlg_windform.Classes
{
    public delegate void Func<in T1, in T2>(T1 t1, T2 t2);
    public class RoundRobinList<T>
    {
        private Queue<RRItem<T>> Items;

        public int Quantom { get; set; } = 1;

        public event Func<int, T> OnGetNext;

        public ulong Tick { get; private set; }

        public RoundRobinList()
        {
            Items = new Queue<RRItem<T>>();
            OnGetNext = (q, item) => { };
        }

        public void AddItem(T item, int time = 1)
        {
            Items.Enqueue(new RRItem<T>(item, time)
            {
                LastUpadateTime = Tick,
                TotalWaitingTime = 0
            });
        }

        public List<T> GetAll()
        {
            return Items.Select(i => i.Data).ToList();
        }

        //public void AddRange(IEnumerable<T> values)
        //{
        //    foreach (var val in values)
        //    {
        //        Items.Enqueue(new RRItem<T>(val));
        //    }
        //}


        public T? GetNext()
        {
            if (Items.Count <= 0)
                return default;

            var item = Items.Dequeue();

            var startTime = Tick;

            if (item.Weight > Quantom)
            {
                Tick += (ulong)Quantom;
                item.DecreaseWeight(Quantom);

                OnGetNext(Quantom, item.Data);
                
                Items.Enqueue(item);
            }
            else
            {
                int w = item.Weight;

                Tick += (uint) w;
                item.DecreaseWeight(item.Weight);

                OnGetNext(w, item.Data);

                if (item.Weight > 0)
                    Items.Enqueue(item);
            }

            item.TotalWaitingTime += (startTime - item.LastUpadateTime);
            item.LastUpadateTime = Tick;

            return item.Data;
        }
    }
}
