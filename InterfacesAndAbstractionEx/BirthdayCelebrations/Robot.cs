using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace BirthdayCelebrations
{
    class Robot : IIdentifiable
    {
        private string model;
        private string id;

        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }

        public string Model { get => model; set => model = value; }
        public string Id { get => id; set => id = value; }

    }
}
