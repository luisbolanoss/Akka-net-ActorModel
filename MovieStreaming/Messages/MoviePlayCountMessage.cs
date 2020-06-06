using System;
using System.Collections.Generic;
using System.Text;

namespace MovieStreaming.Messages
{
    class MoviePlayCountMessage
    {
        public string MovieTitle { get; private set; }

        public int Whatched { get; private set; }
    }
}
