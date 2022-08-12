using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericSwapMethodInteger
{
    public class Box<T>
    {
        public Box()
        {
            this.Items = new List<T>();
        }
      
        public List<T> Items { get; private set; }

        public void Swap(int first, int second)
        { 
            T temp = this.Items[first];
            this.Items[first] = this.Items[second];
            this.Items[second] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            this.Items.ForEach(x => sb.AppendLine($"{x.GetType().FullName}: {x}"));

            return sb.ToString().TrimEnd();
        }
    }
}
