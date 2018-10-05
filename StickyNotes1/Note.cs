using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StickyNotes1
{
   public  class Note
    {
        public int note_id
        {
            get; set;
        }
        public string title
        {
            get; set;
        }
        public string content
        {
            get; set;
        }
        public DateTime create_date
        {
            get; set;
        }
        public bool stickied
        {
            get; set;
        }
        public bool completed
        {
            get; set;
        }
    }
}
