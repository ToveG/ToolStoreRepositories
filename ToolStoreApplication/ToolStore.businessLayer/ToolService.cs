using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolStore.domain;
using ToolStore.domain.Repositories;

namespace ToolStore.businessLayer
{
    public class ToolService
    {
        DataContext dbContext = new DataContext();
        private ToolRepository tool_rep;
        List<Tool> _toolList = new List<Tool>();

        public ToolService()
        {
            tool_rep = new ToolRepository(dbContext);
        }

        //public Tool AddTool(string name, string description, string weight, string price)
        //{
            
        //}
        //public Person Add_person(string fnamn, string enamn, string mail, int phone)
        //{
        //    Person _person = new Person { FirstName = fnamn, LastName = enamn, Epost = mail, Phonenumber = phone };
        //    book_rep.addPerson(_person);
        //    return _person;
        //}

    }

   
}
