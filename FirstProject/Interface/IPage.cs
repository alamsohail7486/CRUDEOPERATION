using FirstProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstProject.Interface
{
   public interface IPage
    {
        //Interface work done b4 repository starts///
        Page InsertPage(Page alam);

        Page UpdatePage(Page alam);

        Page DeletePage(int id);

        IList<Page> GetAllMyPage();

        Page SelectPageById(int id);


    }
}
