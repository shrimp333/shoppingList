using System;

namespace shoppingList
{
    class Item
    {
        public string title;
        public string quantity;
        public string unitPrice;
        public Item(string pTitle, string pQuantity, string pUnitPrice)
        {
            title = pTitle;
            quantity = pQuantity;
            unitPrice = pUnitPrice;
        }
    }
}
