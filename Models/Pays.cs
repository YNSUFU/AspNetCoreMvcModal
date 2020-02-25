using System;
using System.Collections.Generic;

namespace TutoAspNetCoreMvc.Models
{
    public partial class Pays
    {
        public Pays()
        {
            Ville = new HashSet<Ville>();
        }

        public int IdPays { get; set; }
        public string NomPays { get; set; }

        public virtual ICollection<Ville> Ville { get; set; }
    }
}
