using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication3
{
    public static class ClassWriter
    {
        static readonly List<string> ClassLines = new List<string>
        {
            "using System;",
            "using System.Collections.Generic;",
            "using System.Linq;",
            "using System.Threading.Tasks;",
            "using Microsoft.AspNet.OData;",
            "using Microsoft.AspNetCore.Http;",
            "using Microsoft.AspNetCore.Mvc;",
            "using Microsoft.Extensions.Logging;",
            "using Savant.Pulse.DataAccessLayer.ReferenceData;",
            "using Savant.Pulse.DataAccessLayer.ReferenceData.Models;",
            "",
            "namespace Savant.Pulse.WebApi.ReferenceData.Controllers",
            "{",
            "    [Route(\"api/[controller]\")]",
            "    [ApiController]",
            "    public class %classname%Controller : ODataController",
            "    {",
            "",
            "        private readonly PulseReferenceContext _context;",
            "        private readonly ILogger<ReferenceDataApiController> _logger;",
            "",
            "        public %classname%Controller(",
            "            PulseReferenceContext context,",
            "            ILogger<ReferenceDataApiController> logger)",
            "        {",
            "            _context = context;",
            "            _logger = logger;",
            "        }",
            "",
            "        [HttpGet]",
            "        [EnableQuery]",
            "        public IQueryable<%classname%> Get()",
            "        {",
            "            var sp = _context.%classname%;",
            "            return sp;",
            "        }",
            "    }",
            "}"
        };

        public static void CreateClassForDbTable(string tableName)
        {
            tableName = tableName.Trim();

            var newClass = ClassLines.Select(s => s.Replace("%classname%", tableName)).ToList();
            TextWriter tw = new StreamWriter($"c:\\temp\\{tableName}Controller.cs");

            foreach (String s in newClass)
                tw.WriteLine(s);

            tw.Close();

        }
    }
}
