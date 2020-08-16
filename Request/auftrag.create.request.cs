using System.Collections.Generic;
using car_webapi.db.models;

namespace car_webapi.request
{
    public class AuftragCreateRequest
    {
        public Motor Motor { get; set; }
        public Lackierung Lackierung { get; set; }
        public Felgen Felgen { get; set; }
        public List<Sonderausstattung> Sonderausstattung { get; set; }
    }
}