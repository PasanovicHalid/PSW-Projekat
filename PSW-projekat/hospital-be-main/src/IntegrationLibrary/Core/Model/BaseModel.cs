using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntegrationLibrary.Core.Model
{
    public abstract class BaseModel
    {
        private int _id;

        [Key]
        public int Id { get => _id; set => _id = value; }
    }
}
