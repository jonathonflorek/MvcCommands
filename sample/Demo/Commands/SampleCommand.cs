using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MvcCommands;
using System;

namespace Demo
{
    [RoutedCommand("demo/{id}", "POST")]
    public class SampleCommand
    {
        [FromRoute]
        public String Id { get; set; }

        [FromQuery]
        public String Query { get; set; }

        [FromBody]
        public SampleBody Body { get; set; }

        [FromHeader]
        public String Accept { get; set; }

        public class SampleBody
        {
            public String Value { get; set; }
        }
    }
}