using System;
using System.Collections.Generic;

class Comment
{
    private string _commenterName;
    private string _commentText;

    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }

    public string GetCommentDetails()
    {
        return $"{_commenterName}: {_commentText}";
    }
}
