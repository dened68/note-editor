using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace redzam
{
    public class Note
    {
        public string Name;
        public string Content;
        public string CreationDate;

        public void SetName(string name)
        {
            this.Name = name;
        }
        public void SetContent(string content)
        {
            this.Content = content;
        }
        public void SetCreationDate(string creationDate)
        {
            this.CreationDate = creationDate;
        }

        public string GetName()
        {
            return (this.Name);
        }
        public string GetContent()
        {
            return (this.Content);
        }
        public string GetCreationDate()
        {
            return (this.CreationDate);
        }
        
    }
}
