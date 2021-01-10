using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CovidStats.AccessData
{
    public class Bundesland
    {
        public int ID { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = String.Empty;

        [JsonIgnore]
        public List<Bezirk> Bezirke { get; set; }
    }

    public class Bezirk
    {
        public int ID { get; set; }

        public int Code { get; set; }

        [MaxLength(100)]
        [Required]
        public string Name { get; set; } = String.Empty;

        public Bundesland Bundesland { get; set; }

        [JsonIgnore]
        public List<Cases> Cases { get; set; }
    }

    public class Cases
    {
        public int ID { get; set; }

        public DateTime Date { get; set; }

        public Bezirk Bezirk { get; set; }

        public int Population { get; set; }

        public int Infections { get; set; }

        public int Deaths { get; set; }

        public int Incidences { get; set; }
    }
    

}
