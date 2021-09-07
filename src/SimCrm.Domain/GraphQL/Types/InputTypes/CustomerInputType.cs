﻿using GraphQL.Types;
using SimCrm.Domain.Entities;
using System.Collections.Generic;

namespace SimCrm.Domain.GraphQL.Types.InputTypes
{
    public class CustomerInputType: InputObjectGraphType<Customer>
    {
        public CustomerInputType()
        {
            Name = "CustomerInput";

            Field<IntGraphType>("userId");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<DateGraphType>("dateOfBirth");
            Field<StringGraphType>("middleName");
            Field<ListGraphType<EmailAddressInputType>>("emailAddresses");
        }
    }
}
