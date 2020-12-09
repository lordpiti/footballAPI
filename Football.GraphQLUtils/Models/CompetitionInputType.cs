using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Football.GraphQLUtils.Models
{
    public class CompetitionInputType : InputObjectGraphType
    {
        public CompetitionInputType()
        {
        //            public int Id { get; set; }

        //public string Name { get; set; }

        //public string Season { get; set; }

        //public string Type { get; set; }

        //public BlobData Logo { get; set; }

            Name = "CompetitionInput";
            Field<NonNullGraphType<IntGraphType>>("id");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("season");
            Field<NonNullGraphType<StringGraphType>>("type");
        }
    }
}
