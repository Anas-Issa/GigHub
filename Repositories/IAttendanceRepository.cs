﻿using System.Collections.Generic;
using GigHub.Models;

namespace GigHub.Repositories
{
    public interface IAttendanceRepository
    {
        IEnumerable<Attendence> GetFutureAttendances(string userid);
    }
}