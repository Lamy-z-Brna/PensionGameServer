﻿using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Validation.Common
{
    public record ValidationError
    {
        public IEnumerable<string> ErrorMessages { get; init; }

        public bool IsValid => !ErrorMessages.Any();

        public ValidationError(string message)
        {
            ErrorMessages = new List<string> { message };
        }

        public ValidationError(IEnumerable<string> messages)
        {
            ErrorMessages = messages;
        }
    }
}
