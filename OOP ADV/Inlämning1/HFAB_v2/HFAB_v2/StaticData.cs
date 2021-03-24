using System;
using System.Collections.Generic;
using System.Text;

namespace HFAB_v2
{
    class StaticData
    {
        public StaticData() {}


        //Arrays with all names of tenants
        public string[] TenantsArray = {
            "Liam Jönsson",
            "Elias Petterson",
            "Wilma Johansson",
            "Alicia Sanchez",
            "Aaron Sanchez",
            "Olivia Erlander",
            "William Erlander",
            "Alexander Erlander",
            "Astrid Erlander",
            "Lucas Adolfsson",
            "Ebba Adolfsson",
            "Lilly Adolfsson",
            "Ella Ahlström",
            "Alma Alfredsson",
            "Elsa Ahlström",
            "Maja Ahlström",
            "Noah Almgren",
            "Adam Andersen",
            "Kattis Backman",
            "Oscar Chen",
            "Vaktmästare"};
        
        //Arrays with all tags(easy to connect with tenants since they share id# (i <--> i) )
        public string[] TagArray = {
            "0101A",
            "0102A",
            "0102B",
            "0103A",
            "0103B",
            "0201A",
            "0201B",
            "0201C",
            "0201D",
            "0202A",
            "0202B",
            "0202C",
            "0301A",
            "0301B",
            "0301C",
            "0301D",
            "0302A",
            "0302B",
            "0302C",
            "0302D",
            "VAKT01"};

        //Arrays with all locations
        public string[] LocationArray = {
        "0101",
        "0102",
        "0103",
        "0201",
        "0202",
        "0301",
        "0302",
        "SOPRUM",
        "TVÄTT",
        "VAKT"};

        //Arrays with all events
        public string[] EventArray = {
        "DÖIN",
        "DÖUT",
        "FDIN",
        "FDUT"};

        //Arrays with all doors
        public string[] DoorArray = {
        "LGH0101",
        "LGH0102",
        "LGH0103",
        "LGH0201",
        "LGH0202",
        "LGH0301",
        "LGH0302",
        "BLK0101",
        "BLK0102",
        "BLK0103",
        "BLK0201",
        "BLK0202",
        "BLK0301",
        "BLK0302",
        "UT",
        "SOPRUM",
        "TVÄTT",
        "VAKT"
        };
    }
}
