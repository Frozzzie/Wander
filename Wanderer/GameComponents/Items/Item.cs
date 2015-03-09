using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wanderer.GameComponents
{
    public abstract class Item
    {
        public Gold Value { get; set; }

        public virtual String Name { get; set; }
        public virtual String Description { get; set; }

        /// <summary>
        /// Weight in pounds.
        /// </summary>
        public virtual int Weight { get; set; }

    }
}
