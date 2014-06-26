using System.Collections.Generic;
using System.Linq;

namespace Journey.Core.Results
{
    public class ResultCollection : List<IResult>
    {
        public bool? Passed
        {
            get
            {
                if (HasFailure())
                {
                    return false;
                }
                if (HasPending())
                {
                    return null;
                }

                return true;
            }
        }

        private bool HasFailure()
        {
            return this.Any(x => x.WasSuccess.HasValue && !x.WasSuccess.Value);
        }

        private bool HasPending()
        {
            return this.Any(x => !x.WasSuccess.HasValue);
        }
    }
}