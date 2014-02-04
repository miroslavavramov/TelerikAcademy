namespace SchoolHierarchy.Common
{
    using System;
    using System.Collections.Generic;

    interface ICommentable
    {
        string Comments { get; set; }

        void AddComment(string comment);
        void ClearComments();
    }
}
