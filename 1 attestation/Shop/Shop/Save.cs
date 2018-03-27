using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop
{
    class Save
    {
        public List<Brands> brand;
        public Market market;

        public Save(Market market,List<Brands> brand)
        {
            this.market = market;
            this.brand = brand;
        }

        public Market getMarket()
        {
            return market;
        }
        public Brands getBrands()
        {
            return brand;
        }
    }
}
