﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicLecture.Entities.Dtos.Participant
{
    public class ParticipantViewDto
    {
        public string Id { get; set; } = "";
        public string CreatorUserName { get; set; } = "";
        public string Name { get; set; } = "";
        public string Email { get; set; } = "";

    }
}
