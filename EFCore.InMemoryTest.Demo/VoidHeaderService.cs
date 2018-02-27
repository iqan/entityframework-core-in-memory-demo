using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EFCore.InMemoryTest.Demo
{
    public class VoidHeaderService
    {
        private DataContext dataContext;

        public VoidHeaderService(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public void Insert(VoidHeader voidHeader)
        {
            this.dataContext.VoidHeader.Add(voidHeader);
            this.dataContext.SaveChanges();
        }

        public VoidHeader GetVoidHeaderById(int id)
        {
            return this.dataContext.VoidHeader.FirstOrDefault(vh => vh.VoidHeaderId == id);
        }
    }
}
