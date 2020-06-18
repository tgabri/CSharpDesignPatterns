using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetAcademia_Bridge2
{
    public abstract class AbstractMessageFactory
    {
        public abstract AbstractTemplating TemplateFactory();

        public abstract EmailService EmailServiceFactory();

        public abstract IPersonRepository RepoFactory();
    }
}
