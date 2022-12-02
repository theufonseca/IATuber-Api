﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enum
{
    public enum VIDEO_STATUS
    {
        CREATED,
        STARTED,
        CREATING_TITLE,
        CREATING_TEXT,
        CREATING_VOICE,
        CREATING_MUSIC,
        CREATING_VIDEO,
        EDITING_VIDEO,
        UPLOADING,
        FINISHED
    }
}