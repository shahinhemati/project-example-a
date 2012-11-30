using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GB.Album.Entities;

namespace GB.Album.Controller
{
    public interface IGBEntityController
    {
        IGBEntityInfo GetEntityInfo(int questionId, int portalId);

        IGBEntityInfo GetQuestionByContentItem(int p);
    }
}
