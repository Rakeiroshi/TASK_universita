using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TASK_universita.DAL
{
    public interface IDal<G>
    {
        public List<G> FindAll();
        public G? findById(int id);
        public bool insert(G g);
        public bool update(G g);
        public bool delete(int id);
    }
}
