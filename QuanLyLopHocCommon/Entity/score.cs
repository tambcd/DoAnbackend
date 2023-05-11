using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyLopHocCommon.Entity
{
    public class score
    {
        public Guid score_id { get; set; }
        public double score_number { get; set; }
        public int semester { get; set; }
        public int number_credits { get; set; }
        public int score_type { get; set; }
        public string subject_name { get; set; }
        public string school_year { get; set; }
        public string user_code { get; set; }
        public DateTime createday { get; set; }

        public List<string> ListerroImport = new List<string>();


    }
}
