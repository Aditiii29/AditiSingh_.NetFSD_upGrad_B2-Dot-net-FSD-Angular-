using Problem2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2.Repositories
{
    public interface IContactRepository
    {
        void Add(Contact contact);
        List<Contact> GetAll();
        bool Remove(int id);
    }
}
