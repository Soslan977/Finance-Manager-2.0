using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finance_Manager.models
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public bool CategoryType {  get; set; }//true-доход, false-расход
    }
}
