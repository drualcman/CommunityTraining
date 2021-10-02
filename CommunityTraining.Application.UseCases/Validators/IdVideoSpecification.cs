using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityTraining.Application.UseCases.Validators
{
    public class IdVideoSpecification
    {
        public bool IsSatisfy(string id) => !string.IsNullOrEmpty(id);
    }
}
