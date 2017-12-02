using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Models.blueprint.errClass
{
    public class UserErrClass
    {
        public int emailBlankErr = 0;
        public int emailFormatErr = 0;
        public int emailExistErr = 0;
        public int passwordBlankErr = 0;
        public int passwordNotMatchErr = 0;
    }
}