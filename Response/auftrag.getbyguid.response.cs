using System.Collections.Generic;
using car_webapi.db.models;

namespace car_webapi.response
{
    public class AuftragGetByGuidResponse
    {
        public Auftrag Auftrag { get; set; }
        public List<Ausstattung> Ausstattung { get; set; }
    }
}