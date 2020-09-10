using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Wongoo_Application.Models.Favourites
{
    class FavouriteList
    {
        [PrimaryKey,AutoIncrement]
        public int FavId { get; set; }
        public string ListName { get; set; }
        public int TotalProducts { get; set; }
        public string PrintProduct { get; set; }
        [OneToMany]
        public List<FavouriteProduct> favouriteProducts { get; set; }
    }
}
