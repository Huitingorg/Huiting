using Huiting.Common;
using Huiting.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReserveCommon
{
    [Serializable]
    public class ProductInfoQueue : BasicQueue<ProductInfo>
    {
        public void SetMainProduct(ProductInfo pi)
        {
            foreach (ProductInfo item in lstData)
            {
                if (item.MainProduct == true)
                {
                    if (item == pi)
                        continue;
                    else
                        item.MainProduct = false;
                }
            }
        }
    }

    [Serializable]
    public class ProductInfo
    {
        public string ID { get; set; }
        public string Text { get; set; }

        public bool MainProduct { get; set; }
    }
}
