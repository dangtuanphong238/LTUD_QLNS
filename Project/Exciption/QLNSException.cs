using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Exciption
{
    class InsertException : Exception
    {
        public InsertException(String message)
          : base(message)
        {
        }
    }

    class UpdateException : Exception
    {
        public UpdateException(String message)
          : base(message)
        {
        }
    }

    class DeleteException : Exception
    {
        public DeleteException(String message)
          : base(message)
        {
        }
    }

    class FindException : Exception
    {
        public FindException(String message)
          : base(message)
        {
        }
    }

    class SelectException : Exception
    {
        public SelectException(String message)
          : base(message)
        {
        }
    }
}
