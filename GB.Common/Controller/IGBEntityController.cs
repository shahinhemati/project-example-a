using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GB.Common.Entities;

namespace GB.Common.Controller
{
    public interface IGBEntityController
    {
        IGBEntityInfo GetEntityInfo(int questionId, int portalId);
    }
}
