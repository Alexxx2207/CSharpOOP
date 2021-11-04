using System;
using System.Collections.Generic;
using System.Text;

namespace WildFarm.Interfaces
{
    interface IFeedable
    {
        void Feed(Food food);

        IReadOnlyCollection<Type> PrefferedFoods { get; }
    }
}
