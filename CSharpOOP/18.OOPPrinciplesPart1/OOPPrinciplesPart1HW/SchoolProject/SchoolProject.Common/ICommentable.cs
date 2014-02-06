namespace SchoolProject.Common
{
    using System;
    using System.Collections.Generic;
    
    interface ICommentable
    {
        List<string> Comments { get; set; }
        void AddComment(params string[] comments);
    }
}
