using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wongoo_Application.Models.Favourites
{
   public class FavouriteProduct
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Barcode { get; set; }
        [ForeignKey(typeof(FavouriteList))]
        public int FavListId { get; set; }
    }
}
