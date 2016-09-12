using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SK.DDP.BL
{
    public interface IPhotoService
    {
        void RemoveAllData(Guid user);
    }
}
