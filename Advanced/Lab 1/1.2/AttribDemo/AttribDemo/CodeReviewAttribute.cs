using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttribDemo
{
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class, AllowMultiple = true)]
    public class CodeReviewAttribute : Attribute
    {
        public string ReviewerName { get; set; }
        public string ReviewDate { get; set; }
        public bool IsApproved { get; set; }

        public CodeReviewAttribute(string reviewerName, string reviewDate, bool isApproved)
        {
            this.IsApproved = isApproved;
            this.ReviewDate = reviewDate;
            this.ReviewerName = reviewerName;
        }
    }
}
